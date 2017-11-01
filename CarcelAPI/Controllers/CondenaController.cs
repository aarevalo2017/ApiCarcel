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
        public IQueryable<Condena> GetCondenas()
        {
            return db.Condenas;
        }

        // GET: api/Condena/5
        [ResponseType(typeof(Condena))]
        public IHttpActionResult GetCondena(int id)
        {
            Condena condena = db.Condenas.Find(id);
            if (condena == null)
            {
                return NotFound();
            }

            return Ok(condena);
        }

        // PUT: api/Condena/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCondena(int id, Condena condena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condena.Id)
            {
                return BadRequest();
            }

            db.Entry(condena).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondenaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Condena
        [ResponseType(typeof(Condena))]
        public IHttpActionResult PostCondena(Condena condena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Condenas.Add(condena);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = condena.Id }, condena);
        }

        // DELETE: api/Condena/5
        [ResponseType(typeof(Condena))]
        public IHttpActionResult DeleteCondena(int id)
        {
            Condena condena = db.Condenas.Find(id);
            if (condena == null)
            {
                return NotFound();
            }

            db.Condenas.Remove(condena);
            db.SaveChanges();

            return Ok(condena);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondenaExists(int id)
        {
            return db.Condenas.Count(e => e.Id == id) > 0;
        }
    }
}