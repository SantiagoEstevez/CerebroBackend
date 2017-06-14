using Cerebro14.DAL;
using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cerebro14.Services.Controllers
{
    public class SensorController : ApiController
    {
        [HttpGet, Route("api/Sensor/CiudadLatitud/{latCiudad}/CiudadLongitud/{lonCiudad}")]
        public IHttpActionResult Get(double latCiudad, double lonCiudad)
        {
            try
            {
                IDALsensor dalSensor = new DALsensor();

                IDALAsignacionDeRecursos AR = new DALAsignacionDeRecursos();
                CredentialsDB city = AR.GetCredencialesCiudad(latCiudad, lonCiudad, "");
                List<DataSource> lSensores = dalSensor.GetAllSensor(city);
                
                if (!lSensores.Any())
                {
                    return NotFound();
                }                

                return Json(lSensores);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al buscar sensores para la ciudad seleccionada: " + e.Message);
                return InternalServerError();                
            }
        }

        [HttpPost, Route("api/Sensor")]
        public IHttpActionResult Post(DataSource newSensor, Ciudad inCity)
        {
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

        //// PUT: api/Sensor/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //[HttpDelete, Route("api/Sensor")]
        //public IHttpActionResult Delete(DataSource sensor, Ciudad inCity)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    IDALAsignacionDeRecursos cityContext = new DALAsignacionDeRecursos();
        //    CredentialsDB city = cityContext.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

        //    if(city == null)
        //    {
        //        return BadRequest("No existe ciudad");
        //    }

        //    IDALsensor sensorContext = new DALsensor();
        //    DataSource sensorToCheck = sensorContext.GetSensorByID(sensor.Latitude, sensor.Longitude, city);

        //    if(sensorToCheck == null)
        //    {
        //        return BadRequest("No existe sensor");
        //    }

        //    sensorContext.
        //}
    }
}
