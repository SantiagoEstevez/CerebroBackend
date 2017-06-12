using Cerebro14.DAL;
using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Script.Serialization;

namespace Cerebro14.Services.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        // GET api/<controller>
        //[HttpGet]
        public HttpResponseMessage Get()
        {
            User usu1 = new User();

            DateTime dia = new DateTime(1989, 12, 5);

            usu1.CI = "48563787";
            usu1.Email = "www.damian17@gmail.com";
            usu1.Lastname = "carancho";
            usu1.Name = "Damian";
            usu1.Password = "magiamagiamagia";
            usu1.Phone = "094202125";
            usu1.Username = "D4m14n";
            usu1.Lat_edicicio = 150006;
            usu1.Lon_edicicio = 200006;
            usu1.Birthdate = dia;

            List<User> lUser = new List<User>()
            {
                usu1,
            };

            object[] x = new object[2];

            x[0] = new { nombre = "momo 2", lat = "1", lon = "1" };
            x[1] = new { nombre = "momo", lat = "1", lon = "1" };

            IDALUsuarios DALUser = new DALUsuario();

            List<object> ciudades = new List<object>();
            ciudades.Add(new { nombre = "momo 2", lat = "1", lon = "1" });

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonEmpleados = jsonSerialiser.Serialize(ciudades);

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonEmpleados)
            };

            //var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(aaa);
            //return json;
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();

            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<User>));
            //ser.WriteObject(ms, lUser);
            //byte[] json = ms.ToArray();
            //ms.Close();
            //return Encoding.UTF8.GetString(json, 0, json.Length);

            //return lUser;//DALUser.GetAllUserLivingIn(150006, 200006, "Ciudad01");
        }

        [Route("api/Usuario/Login")]
        [HttpPost]
        public IHttpActionResult Login(User user)
        {
            IDALUsuarios dalUsu = new DALUsuario();
            
            if (!ModelState.IsValid /*&& dalUsu.ExistUserByID(user.CI)*/)
            {
                return NotFound();
            }
            
            return Ok(CiudadHelper.CreateToken24hrs());
        }

        // GET api/<controller>/5
        [Route("api/Usuario/{id}")]
        [ResponseType(typeof(User))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            try
            {
                IDALUsuarios Usuarios = new DALUsuario();

                CredentialsDB credDB = CiudadHelper.GetMockCredentials();

                User _usuario = Usuarios.GetUserByID(id, credDB);
                if(_usuario == null)
                {
                    return NotFound();
                }
                return Ok(_usuario);
            }
            catch(Exception e)
            {
                Console.WriteLine("No se encontro ");
                throw;
            }
        }

        // POST api/<controller>
        [Route("api/Usuario/{id}")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(User usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IDALUsuarios UsuariosDB = new DALUsuario();
            UsuariosDB.AddUser(usuario, CiudadHelper.GetMockCredentials());

            return Ok();
        }

        // PUT api/<controller>/5
        [Route("api/Usuario/{id}")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, User usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.CI)
            {
                return BadRequest();
            }

            try
            {
                IDALUsuarios UserDB = new DALUsuario();
                UserDB.UpdateUser(usuario, CiudadHelper.GetMockCredentials());
            }
            catch(Exception e)
            {
                IDALUsuarios UserDB = new DALUsuario();
                if (!UserDB.ExistUserByID(id, CiudadHelper.GetMockCredentials()))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/<controller>/5
        [Route("api/Usuario/{id}")]
        [ResponseType(typeof(User))]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            IDALUsuarios dc = new DALUsuario();
            if(dc.ExistUserByID(id, CiudadHelper.GetMockCredentials()))
            {
                return NotFound();
            }

            dc.DeleteUser(id, CiudadHelper.GetMockCredentials());

            return Ok();
        }
    }
}