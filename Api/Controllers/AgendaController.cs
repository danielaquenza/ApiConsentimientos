using ApiConsentimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class AgendaController : ApiController
    {
        public List<spAgenda_Result> Get(int NumeroIDMedico, DateTime fecha)
        {
            using (ApiConsentimientosV2Entities entities = new ApiConsentimientosV2Entities())
            {
                return entities.spAgenda(NumeroIDMedico, fecha).ToList();
            }
        }
    }
}
