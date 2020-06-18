using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiConsentimientos;

namespace Api.Controllers
{
    public class ConsentimientoInformadoesController : ApiController
    {
        private ApiConsentimientosV2Entities db = new ApiConsentimientosV2Entities();

        // GET: api/ConsentimientoInformadoes
        public IQueryable<ConsentimientoInformado> GetConsentimientoInformado()
        {
            return db.ConsentimientoInformado;
        }

        //// GET: api/ConsentimientoInformadoes/5
        [ResponseType(typeof(ConsentimientoInformado))]
        public IHttpActionResult GetConsentimientoInformado(DateTime fecha, TimeSpan hora, string tipoIdPaciente, int numeroIdPaciente, int codigoCUP)
        {
            ConsentimientoInformado consentimientoInformado = db.ConsentimientoInformado.Where(c => c.fecha == fecha & c.hora == hora && 
            c.tipoIdPaciente == tipoIdPaciente && c.numeroIdPaciente == numeroIdPaciente && c.codigoProcedimiento == codigoCUP).FirstOrDefault();

            if (consentimientoInformado == null)
            {
                return NotFound();
            }

            return Ok(consentimientoInformado);
        }

        //// GET: api/ConsentimientoInformadoes/por paciente
        public List<ConsentimientoInformado> Get(string tipoIdPaciente, int numeroIdPaciente, int numeroIdProfesional)
        {
            return db.ConsentimientoInformado.Where(c => c.tipoIdPaciente == tipoIdPaciente 
            && c.numeroIdPaciente == numeroIdPaciente && c.numeroIdProfesional == numeroIdProfesional).ToList();
        }


        // PUT: api/ConsentimientoInformadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsentimientoInformado(ConsentimientoInformado consentimientoInformado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(consentimientoInformado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsentimientoInformadoExists(consentimientoInformado.fecha, consentimientoInformado.hora, consentimientoInformado.tipoIdPaciente,
                    consentimientoInformado.numeroIdPaciente, consentimientoInformado.codigoProcedimiento))
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

        // POST: api/ConsentimientoInformadoes
        [ResponseType(typeof(ConsentimientoInformado))]
        public IHttpActionResult PostConsentimientoInformado(ConsentimientoInformado consentimientoInformado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConsentimientoInformado.Add(consentimientoInformado);

            try
            {
                db.SaveChanges();
            }
            //catch (DbUpdateException)
            //{
            //    if (ConsentimientoInformadoExists(consentimientoInformado.fecha, consentimientoInformado.hora, consentimientoInformado.tipoIdPaciente,
            //        consentimientoInformado.numeroIdPaciente, consentimientoInformado.codigoProcedimiento))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = consentimientoInformado.tipoIdPaciente }, consentimientoInformado);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsentimientoInformadoExists(DateTime fecha, TimeSpan hora, string tipoIdPaciente, int numeroIdPaciente, int codigoCUP)
        {
            return db.ConsentimientoInformado.Count(e => e.fecha == fecha && e.hora == hora && e.tipoIdPaciente == tipoIdPaciente 
            && e.numeroIdPaciente == numeroIdPaciente && e.codigoProcedimiento == codigoCUP ) > 0;
        }
    }
}