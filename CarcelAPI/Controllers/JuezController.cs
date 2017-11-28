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
    public class JuezController : ApiController
    {
        private CarcelDBContext db = new CarcelDBContext();

        // GET: api/Juez
        public IEnumerable<Object> get()
        {
            return db.Jueces.Select(j => new
            {
                Id = j.Id,
                Nombre = j.Nombre,
                Rut = j.Rut,
                Sexo = j.Sexo,
                Domicilio = j.Domicilio
            });
        }

        // GET: api/Juez/{id}
        public IHttpActionResult get(int id)
        {
            Juez juez = db.Jueces.Find(id);
            if (juez == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Id = juez.Id,
                Nombre = juez.Nombre,
                Rut = juez.Rut,
                Sexo = juez.Sexo,
                Domicilio = juez.Domicilio
            });
        }

        // PUT: api/Juez/{id}
        public IHttpActionResult put(int id, Juez juez)
        {
            db.Entry(juez).State = EntityState.Modified;
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Juez modificado correctamente." });
        }

        // POST: api/Juez
        public IHttpActionResult post(Juez juez)
        {
            db.Jueces.Add(juez);
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Juez agregado correctamente." });
        }

        // DELETE: api/Juez/{id}
        public IHttpActionResult delete(int id)
        {
            Juez juez = db.Jueces.Find(id);
            if (juez == null)
            {
                return NotFound();
            }
            db.Jueces.Remove(juez);
            if (db.SaveChanges() == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Juez eliminado correctamente." });
        }
    }
}