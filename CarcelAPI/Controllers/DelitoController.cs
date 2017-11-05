using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarcelAPI.Models;


namespace CarcelAPI.Controllers
{
    public class DelitoController : ApiController
    {
        private CarcelDBContext db = new CarcelDBContext();

        // GET: api/Delito
        public IEnumerable<Object> get()
        {

            return db.Delitos.Include("CondenaDelito").Select(c => new
            {
                id = c.Id,
                nombre = c.Nombre,
                condenaMaxima = c.CondenaMaxima,
                condenaMinima = c.CondenaMinima

              //  condena = c.CondenaDelitos.Select(cd => new
               // {
                 //   id = cd.Condena.Id,
                   // fechaInicio = cd.Condena.FechaInicioCondena,
                   // fechaCondena = cd.Condena.FechaCondena,
                   // preso = cd.Condena.Preso,
                   // juez = cd.Condena.Juez
                //})
            });
        }

        // GET: api/Delito/{id}
        [ResponseType(typeof(Delito))]
        public IHttpActionResult get(int id)
        {
            var delito = db.Delitos.Include("CondenaDelito").Where(c => c.Id == id).Select(c => new
            {
                id = c.Id,
                nombre = c.Nombre,
                condenaMaxima = c.CondenaMaxima,
                condenaMinima = c.CondenaMinima,

              //  condena = c.CondenaDelitos.Select(cd => new
                //{
                  //  id = cd.Condena.Id,
                  //  fechaInicio = cd.Condena.FechaInicioCondena,
                  //  fechaCondena = cd.Condena.FechaCondena,
                   // preso = cd.Condena.Preso,
                    //juez = cd.Condena.Juez
                //})
            });
            if (delito == null)
            {
                return NotFound();
            }
            return Ok(delito);
        }

        // PUT: api/Delito/{id}
        [ResponseType(typeof(void))]
        public IHttpActionResult put(int id, Delito delito)
        {
            db.Entry(delito).State = EntityState.Modified;
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Delito modificado correctamente." });
        }

        // POST: api/Condena
        public IHttpActionResult post(Delito delito)
        {
            try
            {
                db.Delitos.Add(delito);
                if (db.SaveChanges() == 0)
                {
                    return InternalServerError();
                }
                return Ok(new { mensaje = "Delito agregado correctamente." });
            }
            catch (Exception e)
            {
                return InternalServerError(e);
                //throw;
            }
        }

        // DELETE: api/Delito/1
        [ResponseType(typeof(Delito))]
        public IHttpActionResult DeleteDelito(int id)
        {
            Delito delito = db.Delitos.Find(id);
            if (delito == null)
            {
                return NotFound();
            }
            db.Delitos.Remove(delito);
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Delito eliminado correctamente." });
        }
    }
}