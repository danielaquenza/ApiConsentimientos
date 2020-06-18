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
using ApiConsentimientos;

namespace Api.Controllers
{
    public class ProcedimientoesController : ApiController
    {
        private ApiConsentimientosV2Entities db = new ApiConsentimientosV2Entities();

        // GET: api/Procedimientoes
        public IQueryable<Procedimiento> GetProcedimiento()
        {
            return db.Procedimiento;
        }

        // GET: api/Procedimientoes/5
        [ResponseType(typeof(Procedimiento))]
        public IHttpActionResult GetProcedimiento(int id)
        {
            Procedimiento procedimiento = db.Procedimiento.Find(id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            return Ok(procedimiento);
        }

        // PUT: api/Procedimientoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProcedimiento( Procedimiento procedimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            db.Entry(procedimiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedimientoExists(procedimiento.codigoCUP))
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

        // POST: api/Procedimientoes
        [ResponseType(typeof(Procedimiento))]
        public IHttpActionResult PostProcedimiento(Procedimiento procedimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Procedimiento.Add(procedimiento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProcedimientoExists(procedimiento.codigoCUP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = procedimiento.codigoCUP }, procedimiento);
        }

        // DELETE: api/Procedimientoes/5
        [ResponseType(typeof(Procedimiento))]
        public IHttpActionResult DeleteProcedimiento(int id)
        {
            Procedimiento procedimiento = db.Procedimiento.Find(id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            db.Procedimiento.Remove(procedimiento);
            db.SaveChanges();

            return Ok(procedimiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcedimientoExists(int id)
        {
            return db.Procedimiento.Count(e => e.codigoCUP == id) > 0;
        }
    }
}