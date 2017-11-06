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
    public class CondenaController : ApiController
    {
        private CarcelDBContext db = new CarcelDBContext();

        // GET: api/Condena
        public IEnumerable<Object> get()
        {
            //return db.Condenas;
            return db.Condenas.Include("Preso").Select(c => new
            {
                id = c.Id,
                fechaInicio = c.FechaInicioCondena,
                fechaCondena = c.FechaCondena,
                preso = new
                {
                    nombrePreso = c.Preso.Nombre + " " + c.Preso.Apellido
                },
                delitos = c.CondenaDelitos.Select(cd => new
                {
                    id = cd.Delito.Id,
                    nombre = cd.Delito.Nombre,
                    condenaMaxima = cd.Delito.CondenaMaxima,
                    condenaMinima = cd.Delito.CondenaMinima
                })
            });
        }

        // GET: api/Condena/{id}
        public IHttpActionResult get(int id)
        {
            var condena = db.Condenas.Include("Preso").Where(c => c.Id == id).Select(c => new
            {
                id = c.Id,
                fechaInicio = c.FechaInicioCondena,
                fechaCondena = c.FechaCondena,
                preso = new
                {
                    nombrePreso = c.Preso.Nombre + " " + c.Preso.Apellido
                },
                delitos = c.CondenaDelitos.Select(cd => new
                {
                    id = cd.Delito.Id,
                    nombre = cd.Delito.Nombre,
                    condenaMaxima = cd.Delito.CondenaMaxima,
                    condenaMinima = cd.Delito.CondenaMinima
                })
            });
            if (condena == null)
            {
                return NotFound();
            }
            return Ok(condena);
        }

        // PUT: api/Condena/{id}
        public IHttpActionResult put(Condena condena)
        {
            db.Entry(condena).State = EntityState.Modified;
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Condena modificada correctamente." });
        }

        // POST: api/Condena
        public IHttpActionResult post(Condena condena)
        {
            try
            {
                db.Condenas.Add(condena);
                if (db.SaveChanges() == 0)
                {
                    return InternalServerError();
                }
                return Ok(new { mensaje = "Condena agregada correctamente." });
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Condena/{id}
        [ResponseType(typeof(Condena))]
        public IHttpActionResult delete(int id)
        {
            Condena condena = db.Condenas.Find(id);
            if (condena == null)
            {
                return NotFound();
            }
            db.Condenas.Remove(condena);
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Condena eliminada correctamente." });
        }
    }
}

//Json para agregar condena con uno o varios delitos.
//{
//    "FechaInicioCondena": "01-11-2017",
//    "FechaCondena": "01-10-2017",
//    "PresoId": 3,
//    "JuezId": 1,
//    "CondenaDelitos":[
//	    {
//	        "DelitoId": 4,
//	        "TiempoCondena": 7
//	    },
//	    {
//	        "DelitoId": 5,
//	        "TiempoCondena": 7
//	    }
//	]
//}
