using Cerebro14.DAL;
using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cerebro14.Services.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class EventoController : ApiController
    {
        [HttpGet, Route("api/Evento")]
        public IHttpActionResult Get()
        {
            IDALEventos dbEve = new DALEventos();
            IDALAsignacionDeRecursos dbRec = new DALAsignacionDeRecursos();
            
            List<Event> allEventos = new List<Event>();
            List<CredentialsDB> lCred = dbRec.GetAllCredencialesCiudad();

            foreach (var cred in lCred)
            {
                var cityEvent = dbEve.GetAllEvent(cred);
                if (cityEvent.Any())
                {
                    allEventos.Concat(cityEvent);
                }                
            }
            
            if (!allEventos.Any())
            {
                return NotFound();
            }

            return Json(allEventos);
        }

        [HttpGet, Route("api/Evento/{latitud}/{longitud}/")]
        public IHttpActionResult Get(double latitud, double longitud)
        {
            return Json("Funciono");
        }

        [HttpPost, Route("api/Evento/latitud/{longitud}/latitud/{latitud}/radio/{radio}")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }
    }
}
