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
    [AuthenticationFilter]
    public class CondenaDelitoController : ApiController
    {
        private CarcelDBContext db = new CarcelDBContext();

        // GET: api/CondenaDelito
        public IEnumerable<Object> get()
        {
            //return db.CondenaDelitos;
            return db.CondenaDelitos.Select(cd => new
            {
                Id = cd.Id,
                CondenaId = cd.CondenaId,
                DelitoId = cd.DelitoId,
                TiempoCondena = cd.TiempoCondena
            });
        }

        // GET: api/CondenaDelito/5
        public IHttpActionResult get(int id)
        {
            CondenaDelito cd = db.CondenaDelitos.Find(id);
            if (cd == null)
            {
                return NotFound();
            }
            return Ok(new{
                Id = cd.Id,
                CondenaId = cd.CondenaId,
                DelitoId = cd.DelitoId,
                TiempoCondena = cd.TiempoCondena
            });
        }

        // PUT: api/CondenaDelito/{id}
        public IHttpActionResult put(CondenaDelito condenaDelito)
        {
            db.Entry(condenaDelito).State = EntityState.Modified;
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Delito modificado correctamente." });
        }

        // POST: api/CondenaDelito
        public IHttpActionResult post(CondenaDelito condenaDelito)
        {
            db.CondenaDelitos.Add(condenaDelito);
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Delito agregado correctamente." });
        }

        // DELETE: api/CondenaDelito/{id}
        public IHttpActionResult delete(int id)
        {
            CondenaDelito condenaDelito = db.CondenaDelitos.Find(id);
            if (condenaDelito == null)
            {
                return NotFound();
            }
            db.CondenaDelitos.Remove(condenaDelito);
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Delito eliminado correctamente." });
        }
    }
}