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
        // GET: api/Sensor
        [Route("api/Sensor"), HttpGet]
        public IHttpActionResult Get(double lat, double lon)
        {
            try
            {
                IDALsensor dalSensor = new DALsensor();

                IDALAsignacionDeRecursos AR = new DALAsignacionDeRecursos();
                CredentialsDB creden = AR.GetCredencialesCiudad(lat, lon, "nombreRandom");
                //CredentialsDB creden = CiudadHelper.GetMockCredentials();
                var sensores = dalSensor.GetAllSensor(creden);
                if (!sensores.Any())
                {
                    return NotFound();
                }                

                return Ok(sensores);
            }
            catch(Exception e)
            {
                //Guardar en log error
                return InternalServerError();
                throw;
            }

        }

        // GET: api/Sensor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sensor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sensor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sensor/5
        public void Delete(int id)
        {
        }
    }
}
