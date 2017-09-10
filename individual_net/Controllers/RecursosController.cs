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
    public class RecursosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Recursos
        public IQueryable<Recurso> GetRecursos()
        {
            return db.Recursos;
        }

        // GET: api/Recursos/5
        [ResponseType(typeof(Recurso))]
        public IHttpActionResult GetRecurso(long id)
        {
            Recurso recurso = db.Recursos.Find(id);
            if (recurso == null)
            {
                return NotFound();
            }

            return Ok(recurso);
        }

        // PUT: api/Recursos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecurso(long id, Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recurso.Id)
            {
                return BadRequest();
            }

            db.Entry(recurso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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

        // POST: api/Recursos
        [ResponseType(typeof(Recurso))]
        public IHttpActionResult PostRecurso(Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recursos.Add(recurso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recurso.Id }, recurso);
        }

        // DELETE: api/Recursos/5
        [ResponseType(typeof(Recurso))]
        public IHttpActionResult DeleteRecurso(long id)
        {
            Recurso recurso = db.Recursos.Find(id);
            if (recurso == null)
            {
                return NotFound();
            }

            db.Recursos.Remove(recurso);
            db.SaveChanges();

            return Ok(recurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecursoExists(long id)
        {
            return db.Recursos.Count(e => e.Id == id) > 0;
        }
    }
}