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
using individual_net;
using individual_net.Models;
using System.Web.Http.Cors;

namespace individual_net.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PrestamosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Prestamos
        public IQueryable<Prestamo> GetPrestamos()
        {
            return db.Prestamos;
        }

        // GET: api/Prestamos/5
        [ResponseType(typeof(Prestamo))]
        public IHttpActionResult GetPrestamo(long id)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return Ok(prestamo);
        }

        // PUT: api/Prestamos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrestamo(long id, Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo.Id)
            {
                return BadRequest();
            }

            db.Entry(prestamo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
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

        // POST: api/Prestamos
        [ResponseType(typeof(Prestamo))]
        public IHttpActionResult PostPrestamo(Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestamos.Add(prestamo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prestamo.Id }, prestamo);
        }

        // DELETE: api/Prestamos/5
        [ResponseType(typeof(Prestamo))]
        public IHttpActionResult DeletePrestamo(long id)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            db.Prestamos.Remove(prestamo);
            db.SaveChanges();

            return Ok(prestamo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestamoExists(long id)
        {
            return db.Prestamos.Count(e => e.Id == id) > 0;
        }
    }
}