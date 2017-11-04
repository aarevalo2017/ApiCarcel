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
    public class CondenaDelitoController : ApiController
    {
        private CarcelDBContext db = new CarcelDBContext();

        // GET: api/CondenaDelito
        public IQueryable<CondenaDelito> GetCondenaDelitos()
        {
            return db.CondenaDelitos;
        }

        // GET: api/CondenaDelito/5
        [ResponseType(typeof(CondenaDelito))]
        public IHttpActionResult GetCondenaDelito(int id)
        {
            CondenaDelito condenaDelito = db.CondenaDelitos.Find(id);
            if (condenaDelito == null)
            {
                return NotFound();
            }

            return Ok(condenaDelito);
        }

        // PUT: api/CondenaDelito/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCondenaDelito(int id, CondenaDelito condenaDelito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condenaDelito.Id)
            {
                return BadRequest();
            }

            db.Entry(condenaDelito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondenaDelitoExists(id))
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

        // POST: api/CondenaDelito
        [ResponseType(typeof(CondenaDelito))]
        public IHttpActionResult PostCondenaDelito(CondenaDelito condenaDelito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CondenaDelitos.Add(condenaDelito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = condenaDelito.Id }, condenaDelito);
        }

        // DELETE: api/CondenaDelito/5
        [ResponseType(typeof(CondenaDelito))]
        public IHttpActionResult DeleteCondenaDelito(int id)
        {
            CondenaDelito condenaDelito = db.CondenaDelitos.Find(id);
            if (condenaDelito == null)
            {
                return NotFound();
            }

            db.CondenaDelitos.Remove(condenaDelito);
            db.SaveChanges();

            return Ok(condenaDelito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondenaDelitoExists(int id)
        {
            return db.CondenaDelitos.Count(e => e.Id == id) > 0;
        }
    }
}