using Cerebro14.DAL;
using Cerebro14.Model;
using Cerebro14.Model.Auxiliar;
using Cerebro14.Model.SensorTypes;
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
    public class SensorController : ApiController
    {
        [HttpGet, Route("api/Sensor/CiudadLatitud/{latCiudad}/CiudadLongitud/{lonCiudad}/")]
        public IHttpActionResult Get(double latCiudad, double lonCiudad)
        {
            try
            {
                IDALsensor dalSensor = new DALsensor();

                IDALAsignacionDeRecursos AR = new DALAsignacionDeRecursos();
                CredentialsDB city = AR.GetCredencialesCiudad(latCiudad, lonCiudad, "");
                List<DataSource> lSensores = dalSensor.GetAllSensor(city); 

                //if (!lSensores.Any())
                //{
                //    return NotFound();
                //}                

                return Json(lSensores);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al buscar sensores para la ciudad seleccionada: " + e.Message);
                return InternalServerError();                
            }
        }

        [HttpPost, Route("api/Sensor")]
        public IHttpActionResult Post(AuxSensorAngular newDataSource)
        {
            DataSource newSensor = new SensorHumidity()
            {
                Tipo = newDataSource.Tipo,
                Latitude = newDataSource.Latitude,
                Longitude = newDataSource.Longitude
            };

            Ciudad inCity = new Ciudad()
            {
                Nombre = newDataSource.ciudad,
                Latitud = newDataSource.cLatitud,
                Longitud = newDataSource.cLongitude
            };

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IDALsensor sensorContext = new DALsensor();
                IDALAsignacionDeRecursos cityContext = new DALAsignacionDeRecursos();

                CredentialsDB city = cityContext.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, "");
                if (city == null)
                {
                    return BadRequest("No existe ciudad");
                }

                sensorContext.AddSensor(newSensor, city);

                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al crear sensor: " + e.Message);
                return InternalServerError();
            } 
        }

        [HttpGet, Route("api/Sensor/Tipos")]
        public IHttpActionResult Get()
        {
            return Json(CiudadHelper.TipoSensoresCiudad());
        }
    }
}
