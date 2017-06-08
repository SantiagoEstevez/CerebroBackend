using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Cerebro14.Services.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CiudadController : ApiController
    {
        // GET: api/Ciudad
        [Route("api/Ciudad/{id}")]
        [ResponseType(typeof(Ciudad))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                CredentialsDB creden = new CredentialsDB();
                creden.NameDbM = "cerebro201701";
                creden.NameDbSQL = "Ciudad01";
                creden.PassDb = "5h5thg5@tgdhfGhuiOu";
                creden.PortServerDb = 28540;
                creden.UserDb = "AdminDB";

                //IDALCiudad DBCiudad = new IDALECiudad();

                Ciudad cui = new Ciudad()
                {
                    Nombre = "Petevideo",
                    Longitud = (float)-34.9011127,
                    Latitud = (float)-56.16453139999999,                    
                    DatabaseInfo = creden
                };
                return Ok(cui);
            }
            catch (Exception e)
            {
                Console.WriteLine("No se puedo enviar la ciudad");
                throw;
            }
        }

        // GET: api/Ciudad/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ciudad
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ciudad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ciudad/5
        public void Delete(int id)
        {
        }
    }
}
