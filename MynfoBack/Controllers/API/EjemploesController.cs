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
using MynfoBack.Models;

namespace MynfoBack.Controllers.API
{
    public class EjemploesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Ejemploes
        public IQueryable<Ejemplo> GetEjemploes()
        {
            return db.Ejemploes;
        }

        // GET: api/Ejemploes/5
        [ResponseType(typeof(Ejemplo))]
        public IHttpActionResult GetEjemplo(int id)
        {
            Ejemplo ejemplo = db.Ejemploes.Find(id);
            if (ejemplo == null)
            {
                return NotFound();
            }

            return Ok(ejemplo);
        }

        // PUT: api/Ejemploes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEjemplo(int id, Ejemplo ejemplo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ejemplo.EjemploID)
            {
                return BadRequest();
            }

            db.Entry(ejemplo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjemploExists(id))
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

        // POST: api/Ejemploes
        [ResponseType(typeof(Ejemplo))]
        public IHttpActionResult PostEjemplo(Ejemplo ejemplo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ejemploes.Add(ejemplo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ejemplo.EjemploID }, ejemplo);
        }

        // DELETE: api/Ejemploes/5
        [ResponseType(typeof(Ejemplo))]
        public IHttpActionResult DeleteEjemplo(int id)
        {
            Ejemplo ejemplo = db.Ejemploes.Find(id);
            if (ejemplo == null)
            {
                return NotFound();
            }

            db.Ejemploes.Remove(ejemplo);
            db.SaveChanges();

            return Ok(ejemplo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EjemploExists(int id)
        {
            return db.Ejemploes.Count(e => e.EjemploID == id) > 0;
        }
    }
}