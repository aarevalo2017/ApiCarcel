using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using CarcelAPI.Models;


namespace CarcelAPI.Controllers
{
    [AuthenticationFilter]
    public class DelitoController : ApiController
    {
        private CarcelDBContext db = new CarcelDBContext();

        // GET: api/Delito
        public IEnumerable<Object> get()
        {
            return db.Delitos.Include("CondenaDelito").Select(d => new
            {
                Id = d.Id,
                Nombre = d.Nombre,
                CondenaMaxima = d.CondenaMaxima,
                CondenaMinima = d.CondenaMinima
            });
        }

        // GET: api/Delito/{id}
        public IHttpActionResult get(int id)
        {
            var delito = db.Delitos.Include("CondenaDelito").Where(c => c.Id == id).Select(d => new
            {
                id = d.Id,
                nombre = d.Nombre,
                condenaMaxima = d.CondenaMaxima,
                condenaMinima = d.CondenaMinima,
            });
            if (delito == null)
            {
                return NotFound();
            }
            return Ok(delito);
        }

        // PUT: api/Delito/{id}
        public IHttpActionResult put(Delito delito)
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
            }
        }

        // DELETE: api/Delito/{id}
        public IHttpActionResult delete(int id)
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