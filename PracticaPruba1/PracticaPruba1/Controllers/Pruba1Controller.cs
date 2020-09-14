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
using PracticaPruba1.Models;

namespace PracticaPruba1.Controllers
{
    public class Pruba1Controller : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Pruba1
        [Authorize]
        public IQueryable<Pruba1> GetPruba1()
        {
            return db.Pruba1;
        }

        // GET: api/Pruba1/5
        [Authorize]
        [ResponseType(typeof(Pruba1))]
        public IHttpActionResult GetPruba1(int id)
        {
            Pruba1 pruba1 = db.Pruba1.Find(id);
            if (pruba1 == null)
            {
                return NotFound();
            }

            return Ok(pruba1);
        }

        // PUT: api/Pruba1/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPruba1(int id, Pruba1 pruba1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pruba1.ZambranaID)
            {
                return BadRequest();
            }

            db.Entry(pruba1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pruba1Exists(id))
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

        // POST: api/Pruba1
        [Authorize]
        [ResponseType(typeof(Pruba1))]
        public IHttpActionResult PostPruba1(Pruba1 pruba1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pruba1.Add(pruba1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pruba1.ZambranaID }, pruba1);
        }

        // DELETE: api/Pruba1/5
        [Authorize]
        [ResponseType(typeof(Pruba1))]
        public IHttpActionResult DeletePruba1(int id)
        {
            Pruba1 pruba1 = db.Pruba1.Find(id);
            if (pruba1 == null)
            {
                return NotFound();
            }

            db.Pruba1.Remove(pruba1);
            db.SaveChanges();

            return Ok(pruba1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pruba1Exists(int id)
        {
            return db.Pruba1.Count(e => e.ZambranaID == id) > 0;
        }
    }
}