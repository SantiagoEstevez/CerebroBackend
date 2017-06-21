using Cerebro14.DAL;
using Cerebro14.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
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
        //-------------------------> Manejo del token de autenticacion. <-------------------------
        public const string Secret = "856FECBA3B06519C8DDDBC80BB080553"; // your symmetric

        [HttpPost, Route("api/Usuario/Login")]
        public IHttpActionResult LoginBackend(User user)
        {
            //user = new User();
            //user.Password = "asasd";
            //user.Username = "nombre";

            //return Json(CiudadHelper.CreateToken24hrs());
            //return Json(GenerateToken("asasaasasasaa"));
            if (CheckUser(user))
            {
                return Json(GenerateToken(user.Username));
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(User user)
        {
            // should check in the database
            if (user.Username == "test" && user.Password == "test")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string GenerateToken(string username, int expireMinutes = 20)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name, username)
                    }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
        //[JwtAuthentication]
        //-------------------------> Fin Manejo del token de autenticacion. <-------------------------

        //[HttpPost, Route("api/Usuario/Login")]        
        //public IHttpActionResult LoginBackend(User user)
        //{
        //    IDALUsuarios dalUsu = new DALUsuario();

        //    if (!ModelState.IsValid)
        //    {
        //        return NotFound();
        //    }            

        //    //Checkear si existe admin con esa cedula o lo que sea

        //    return Json(CiudadHelper.CreateToken24hrs());
        //}

        // GET api/<controller>/5
        [HttpGet, Route("api/Usuario/{ci}/CiudadLat/{cityLat}/CiudadLon/{cityLon}/")]
        public IHttpActionResult Get(int ci, double cityLat, double cityLon)
        {
            try
            {
                IDALUsuarios userContext = new DALUsuario();
                IDALAsignacionDeRecursos cityContext = new DALAsignacionDeRecursos();

                CredentialsDB city = cityContext.GetCredencialesCiudad(cityLat, cityLon, ""); 
                if(city == null)
                {
                    return BadRequest();
                }

                User usuario = userContext.GetUserByID(ci, city);
                if(usuario == null)
                {
                    return NotFound();
                }

                return Json(usuario);
            }
            catch(Exception e)
            {
                Console.WriteLine("No se encontro usuario: " + e.Message);
                return InternalServerError();
            }
        }

        // POST api/<controller>
        [HttpPost, Route("api/Usuario")]
        public IHttpActionResult Post(User usuario, Ciudad inCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IDALAsignacionDeRecursos cityContext = new DALAsignacionDeRecursos();
            CredentialsDB city = cityContext.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, "");
            if(city == null)
            {
                return BadRequest("No existe ciudad");
            }

            IDALUsuarios userContext = new DALUsuario();
            if (!userContext.ExistUserByID(usuario.CI, city))
            {
                return BadRequest("No existe usuario en ciudad");
            }

            userContext.AddUser(usuario, city);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut, Route("api/Usuario")]
        public IHttpActionResult Put(User usuario, Ciudad inCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IDALAsignacionDeRecursos cityContext = new DALAsignacionDeRecursos();
            CredentialsDB city = cityContext.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, "");
            if (city == null)
            {
                return BadRequest("No existe ciudad");
            }

            IDALUsuarios userContext = new DALUsuario();
            if (!userContext.ExistUserByID(usuario.CI, city))
            {
                return BadRequest("No existe usuario en ciudad");
            }

            userContext.UpdateUser(usuario, city);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("api/Usuario/{ci}")]
        public IHttpActionResult Delete(int ci, Ciudad inCity)
        {
            IDALAsignacionDeRecursos cityContext = new DALAsignacionDeRecursos();
            CredentialsDB city = cityContext.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, "");
            if (city == null)
            {
                return BadRequest("No existe ciudad");
            }

            IDALUsuarios userContext = new DALUsuario();
            if(!userContext.ExistUserByID(ci, city))
            {
                return NotFound();
            }

            userContext.DeleteUser(ci, city);
            return Ok();
        }
    }
}