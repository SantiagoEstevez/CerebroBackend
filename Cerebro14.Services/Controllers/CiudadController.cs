using Cerebro14.DAL;
using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Script.Serialization;

namespace Cerebro14.Services.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CiudadController : ApiController
    {
        // GET: api/Ciudad
        [HttpGet, Route("api/Ciudad")]
        public IHttpActionResult Get()
        {
            try
            {
                //CredentialsDB creden = CiudadHelper.GetMockCredentials();

                //Ciudad cui = new Ciudad()
                //{
                //    Nombre = "Petevideo",
                //    Longitud = (float)-34.9011127,
                //    Latitud = (float)-56.16453139999999,
                //    DatabaseInfo = creden
                //};

                //List<Ciudad> lCiudad = new List<Ciudad>();
                //lCiudad.Add(cui); lCiudad.Add(cui);

                //if (!lCiudad.Any())
                //{
                //    return NotFound();
                //}

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("No se puedo enviar la ciudad: " + e.Message);
                return NotFound();
            }
        }

        // GET: api/Ciudad/5
        [HttpGet, Route("api/Ciudad/latitud/{latitud}/longitud/{longitud}")]
        public IHttpActionResult Get(double latitud, double longitud)
        {
            try
            {
                IDALAsignacionDeRecursos ADR = new DALAsignacionDeRecursos();
                ADR.GetCredencialesCiudad(latitud, longitud, "");
                //nuevaCiudad.TodasLasCiudades();                

                //if (lCiudades.Any() == null)
                //{
                //    return NotFound();
                //}

                //return Json(lCiudades);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("No se puedo enviar la ciudad: " + e.Message);
                return NotFound();
            }
        }

        // POST: api/Ciudad
        [Route("api/Ciudad"), HttpPost]
        public IHttpActionResult Post(Ciudad nuevaCiudad)
        {
            IDALAsignacionDeRecursos nuevaCredencialCiudad = new DALAsignacionDeRecursos();
            CredentialsDB ciuCred = nuevaCredencialCiudad.GetCredencialesCiudad(nuevaCiudad.Longitud, nuevaCiudad.Longitud, nuevaCiudad.Nombre);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Thread t = new Thread();

            //t.Start();
            //t.Name = nuevaCiudad.Nombre;

            //return CreatedAtRoute("DefaultApi", new { controller = "CambioAlcance", id = cambioAlcacne.ID }, cambioAlcacne);
            return Ok();
        }

        // PUT: api/Ciudad/5
        public IHttpActionResult Put(string nombre, Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (nombre != ciudad.Nombre)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Ciudad/5
        [Route("api/CambioAlcance/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string nombre)
        {
            //GetById, si no lo encuentro:
            //if (cambioAlcance == null)
            //{
            //    return NotFound();
            //}

            //Sistema de control de borrado
            //if (CambioAlcanceApi.CanDelete(DC, id))
            //{
            //    cambioAlcance.Deleted = true;
            //    CambioAlcanceApi.Update(DC, cambioAlcance);
            //    DeleteTareas(cambioAlcance.ID);

            //    return Ok(new DeleteResult
            //    {
            //        Success = true,
            //        Message = "Se ha eliminado con éxito el Cambio de Alcance."
            //    });
            //}
            //else
            //{
            //    return Ok(new DeleteResult
            //    {
            //        Success = false,
            //        Message = "No se puede eliminar el Cambio de Alcance por que existen horas cargadas a alguna de sus tareas."
            //    });
            //}
            return Ok();
        }
    }
}
