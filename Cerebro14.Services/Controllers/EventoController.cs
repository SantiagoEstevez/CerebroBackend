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
        public IHttpActionResult GetAllEventsAndZones()
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
                    foreach(var evento in cityEvent)
                    {
                        allEventos.Add(evento);
                    }                    
                }
            }

            return Json(allEventos);
        }

        [HttpGet, Route("api/Evento/Zone/cityLat/{cityLat}/cityLon/{cityLon}/")]
        public IHttpActionResult GetAllZoneEvents(double cityLat, double cityLon)
        {
            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();
            
            if(!DBCiudades.ExistCredencialCiudad(cityLat, cityLon))
            {
                return BadRequest();
            }

            CredentialsDB city = DBCiudades.GetCredencialesCiudad(cityLat, cityLon, "");
            List<Event> cityEvent = DBEventos
                                    .GetAllEvent(city)
                                    .Where(x => x.Latitude != 0 && x.Radio == 0)
                                    .ToList();
                        
            List<Event> cityZones = DBEventos
                                    .GetAllEvent(city)
                                    .Where(x => x.Radio > 0)
                                    .ToList();

            List<Event> ret = new List<Event>();
            foreach(var zone in cityZones)
            {
                ret.Concat(cityEvent
                            .Where(x => EventLogic.EventIsInsideZone(zone, x))
                            .ToList())
                            .Distinct();
            }

            return Json(ret);
        }

        [HttpGet, Route("api/Evento/Zone/cityLat/{cityLat}/cityLon/{cityLon}/zoneLat/{zoneLat}/zoneLon/{zoneLon}/zoneRad/{zoneRad}/")]
        public IHttpActionResult GetZoneEvent(double cityLat, double cityLon, double zoneLat, double zoneLon, double zoneRad)
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("api/Evento/EventoZona")]
        public IHttpActionResult PostZoneEvent([FromBody] AuxEventoAngular newEvento)
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

            if (newEvento.Radio > 0 || newEvento.Latitude == 0 || newEvento.Longitude == 0)
            {
                return BadRequest();
            }

            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();
            IDALEventoSensor DBEventoSensor = new DALEventoSensor();

            CredentialsDB inCityCred = DBCiudades.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

            foreach(var sensor in newEvento.SendoresAsociados)
            {
                DBEventoSensor.CreateAction(newEvent.Latitude, newEvent.Longitude, sensor.Latitude, sensor.Longitude, double.Parse(sensor.Umbral), sensor.Tipo, inCityCred);
            }            

            DBEventos.AddEvent(newEvent, inCityCred);
            
            return Json("Message: Exito");
        }

        [HttpGet, Route("api/Evento/Global/cityLat/{cityLat}/cityLon/{cityLon}/")]
        public IHttpActionResult GetAllGlobalEvents(double cityLat, double cityLon)
        {
            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            if(!DBCiudades.ExistCredencialCiudad(cityLat, cityLon))
            {
                return BadRequest();
            }

            CredentialsDB city = DBCiudades.GetCredencialesCiudad(cityLat, cityLon, "");
            List<Event> allGlobalEvents = DBEventos.GetAllEvent(city).Where(x => x.Latitude == 0 && x.Radio == 0).ToList();
            
            return Json(allGlobalEvents);
        }

        [HttpGet, Route("api/Evento/Global/cityLat/{cityLat}/cityLon/{cityLon}/zoneLat/{zoneLat}/zoneLon/{zoneLon}/zoneRad/{zoneRad}/")]
        public IHttpActionResult GetGlobalEvent(double cityLat, double cityLon, double zoneLat, double zoneLon, double zoneRad)
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("api/Evento/Global")]
        public IHttpActionResult PostGlobal([FromBody] AuxEventoAngular newEvento)
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

            if (!(newEvento.Radio == 0 || newEvento.Latitude == 0 || newEvento.Longitude != 0))
            {
                return BadRequest();
            }

            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB inCityCred = DBCiudades.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

            IDALEventoSensor DBEventoSensor = new DALEventoSensor();
            foreach (var sensor in newEvento.SendoresAsociados)
            {
                DBEventoSensor.CreateAction(newEvent.Latitude, newEvent.Longitude, sensor.Latitude, sensor.Longitude, double.Parse(sensor.Umbral), sensor.Tipo, inCityCred);
            }

            DBEventos.AddEvent(newEvent, inCityCred);

            return Json("Message: Exito");
        }

        [HttpGet, Route("api/Evento/Zona/cityLat/{cityLat}/cityLon/{cityLon}/")]
        public IHttpActionResult GetAllZones (double cityLat, double cityLon)
        {
            IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
            IDALEventos DBEventos = new DALEventos();

            CredentialsDB city = DBCiudades.GetCredencialesCiudad(cityLat, cityLon, "");
            List<Event> cityEvent = DBEventos.GetAllEvent(city).Where(x => x.Radio > 0).ToList();

            return Json(cityEvent);
        }

        [HttpPost, Route("api/Evento/Zona")]
        public IHttpActionResult PostZone([FromBody] AuxZonaAngular newZona)
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
