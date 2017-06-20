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

            //if (!allEventos.Any())
            //{
            //    return NotFound();
            //}

            return Json(allEventos);
        }

        [HttpPost, Route("api/Evento/EventoZona")]
        public IHttpActionResult PostZona(AuxEventoAngular newEvento)
        {
            Event newEvent = new Event()
            {
                Name = newEvento.Nombre,
                Latitude = newEvento.Latitude,
                Longitude = newEvento.Longitude,
                Radio = newEvento.Radio
            };

            Ciudad inCity = new Ciudad()
            {
                Nombre = newEvento.ciudad,
                Latitud = newEvento.cLatitude,
                Longitud = newEvento.cLongitude
            };

            if(newEvento.Radio > 0 || newEvento.Latitude == 0 || newEvento.Longitude == 0)
            {
                return BadRequest();
            }

            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB inCityCred = DBCiudades.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

            DBEventos.AddEvent(newEvent, inCityCred);

            return Json("Message: Exito");
        }

        [HttpPost, Route("api/Evento/EventoGlobal")]
        public IHttpActionResult PostGlobal(AuxEventoAngular newEvento)
        {
            Event newEvent = new Event()
            {
                Name = newEvento.Nombre,
                Latitude = newEvento.Latitude,
                Longitude = newEvento.Longitude,
                Radio = newEvento.Radio
            };

            Ciudad inCity = new Ciudad()
            {
                Nombre = newEvento.ciudad,
                Latitud = newEvento.cLatitude,
                Longitud = newEvento.cLongitude
            };

            if (newEvento.Radio == 0 || newEvento.Latitude == 0 || newEvento.Longitude == 0)
            {
                return BadRequest();
            }

            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB inCityCred = DBCiudades.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

            DBEventos.AddEvent(newEvent, inCityCred);

            return Json("Message: Exito");
        }

        [HttpGet, Route("api/Evento/Zona/cityLat/{cityLat}/cityLon/{cityLon}/")]
        public IHttpActionResult Get(double cityLat, double cityLon)
        {
            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB city = DBCiudades.GetCredencialesCiudad(cityLat, cityLon, "");
            List<Event> cityEvent = DBEventos.GetAllEvent(city).Where(x => x.Radio > 0).ToList();

            return Json(cityEvent);
        }

        [HttpPost, Route("api/Evento/Zona")]
        public IHttpActionResult Post(AuxZonaAngular newZona)
        {
            Event newEvent = new Event()
            {
                Name = newZona.Nombre,
                Latitude = newZona.Latitude,
                Longitude = newZona.Longitude,
                Radio = newZona.Radio
            };

            Ciudad inCity = new Ciudad()
            {
                Nombre = newZona.ciudad,
                Latitud = newZona.cLatitude,
                Longitud = newZona.cLongitude
            };
            
            if(!(newEvent.Radio > 0))
            {
                return BadRequest();
            }

            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB inCityCred = DBCiudades.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

            DBEventos.AddEvent(newEvent, inCityCred);

            return Json("Message: Exito");
        }
    }
}
