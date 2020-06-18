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
    public class PacientesController : ApiController
    {
        private ApiConsentimientosV2Entities db = new ApiConsentimientosV2Entities();

        // GET: api/Pacientes
        public IQueryable<Paciente> GetPaciente()
        {
            return db.Paciente;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult GetPaciente(string tipoId, int numeroId)
        {
            //Paciente paciente = db.Paciente.Find(tipoId, numeroId);

            Paciente paciente = db.Paciente
                                    .Where(p => p.tipoId == tipoId && p.numeroId == numeroId)
                                    .FirstOrDefault();

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(paciente.tipoId, paciente.numeroId))
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

        // POST: api/Pacientes
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paciente.Add(paciente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PacienteExists(paciente.tipoId, paciente.numeroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paciente.tipoId }, paciente);
        }

        //// DELETE: api/Pacientes/5
        //[ResponseType(typeof(Paciente))]
        //public IHttpActionResult DeletePaciente(string id)
        //{
        //    Paciente paciente = db.Paciente.Find(id);
        //    if (paciente == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Paciente.Remove(paciente);
        //    db.SaveChanges();

        //    return Ok(paciente);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(string tipoId, int numeroId)
        {
            return db.Paciente.Count(e => e.tipoId == tipoId && e.numeroId == numeroId) > 0;
        }
    }
}