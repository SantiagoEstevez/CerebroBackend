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
        public IHttpActionResult Get()
        {
            IDALsensor dalSensor = new DALsensor();

            CredentialsDB creden = CiudadHelper.GetMockCredentials();

            var sensores = dalSensor.GetAllSensor(creden);

            return Ok(sensores);
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
