using Cerebro14.DAL;
using Cerebro14.Model;
using Cerebro14.Model.Auxiliar;
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

        [HttpGet, Route("api/Evento/Zonas/cityLat/{cityLat}/cityLon/{cityLon}/")]
        public IHttpActionResult Get(double cityLat, double cityLon)
        {
            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB city = DBCiudades.GetCredencialesCiudad(cityLat, cityLon, "");
            List<Event> cityEvent = DBEventos.GetAllEvent(city).Where(x => x.Radio > 0).ToList();
            
            if (!cityEvent.Any())
            {
                return NotFound();
            }

            return Json(cityEvent);
        }

        [HttpPost, Route("api/Evento/Zona")]
        public IHttpActionResult Post(AuxZonaAngular newZona)
        {
            Event newEvent = new Event()
            {
                Name = newZona.Name,
                Latitude = newZona.Latitude,
                Longitude = newZona.Longitude,
                Radio = newZona.Radio
            };

            Ciudad inCity = new Ciudad()
            {
                Nombre = newZona.ciudad,
                Latitud = newZona.Latitude,
                Longitud = newZona.Longitude
            };
            
            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB inCityCred = DBCiudades.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

            DBEventos.AddEvent(newEvent, inCityCred);

            return Json("Message: Exito");
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
