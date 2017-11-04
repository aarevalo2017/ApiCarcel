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
        public IQueryable<Delito> GetDelitos()
        {
            return db.Delitos;
        }

        // GET: api/Delito/5
        [ResponseType(typeof(Delito))]
        public IHttpActionResult GetDelito(int id)
        {
            Delito delito = db.Delitos.Find(id);
            if (delito == null)
            {
                return NotFound();
            }

            return Ok(delito);
        }

        // PUT: api/Delito/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDelito(int id, Delito delito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != delito.Id)
            {
                return BadRequest();
            }

            db.Entry(delito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DelitoExists(id))
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

        // POST: api/Delito
        [ResponseType(typeof(Delito))]
        public IHttpActionResult PostDelito(Delito delito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Delitos.Add(delito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = delito.Id }, delito);
        }

        // DELETE: api/Delito/5
        [ResponseType(typeof(Delito))]
        public IHttpActionResult DeleteDelito(int id)
        {
            Delito delito = db.Delitos.Find(id);
            if (delito == null)
            {
                return NotFound();
            }

            db.Delitos.Remove(delito);
            db.SaveChanges();

            return Ok(delito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DelitoExists(int id)
        {
            return db.Delitos.Count(e => e.Id == id) > 0;
        }
    }
}