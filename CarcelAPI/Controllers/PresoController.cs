using CarcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarcelAPI.Controllers
{
    public class PresoController : ApiController
    {
        private CarcelDBContext context;

        public PresoController()
        {
            this.context = new CarcelDBContext();
        }

        //Listar 
        public IEnumerable<Object> get()
        {
            return context.Presos.Include("Condenas").
                Select(p => new
                {

                    Id = p.Id,
                    RUT = p.Rut,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    FechaNacimiento = p.FechaNacimiento,
                    Domicilio = p.Domicilio,
                    Sexo = p.Sexo,

                    Condenas = p.Condenas.Select(c => new
                    {
                        Id = c.Id,
                        FechaInicioCondena = c.FechaInicioCondena,
                        FechaCondena = c.FechaCondena,
                        CondenaDelitos = c.CondenaDelitos.Select(cd => new
                        {
                            IdDelito = cd.Delito.Id,
                            Nombre = cd.Delito.Nombre
                        })
                    })
                });

        }



        //api/clientes/{id}
        public IHttpActionResult get(int id)
        {
            var presos = context.Presos.Include("Condenas").Where(c=>c.Id == id).
                Select(p => new
                {

                    Id = p.Id,
                    RUT = p.Rut,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    FechaNacimiento = p.FechaNacimiento,
                    Domicilio = p.Domicilio,
                    Sexo = p.Sexo,

                    Condenas = p.Condenas.Select(c => new
                    {
                        Id = c.Id,
                        FechaInicioCondena = c.FechaInicioCondena,
                        FechaCondena = c.FechaCondena,
                        CondenaDelitos = c.CondenaDelitos.Select(cd => new
                        {
                            IdDelito = cd.Delito.Id,
                            Nombre = cd.Delito.Nombre
                        })
                    })
                });

            if (presos == null) { return NotFound(); }
            return Ok(presos);
        }

        //api/clientes
        public IHttpActionResult post(Preso preso)
        {

            context.Presos.Add(preso);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }


        //api/clientes/{id}
        public IHttpActionResult delete(int id)
        {
            //buscamos el cliente a eliminar
            Preso preso = context.Presos.Find(id);

            if (preso == null) return NotFound();//404

            context.Presos.Remove(preso);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }

        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

















    }
}

