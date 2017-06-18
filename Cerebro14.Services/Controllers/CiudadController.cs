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
        [HttpGet, Route("api/Ciudad")]
        public IHttpActionResult Get()
        {
            try
            {
                IDALAsignacionDeRecursos ade = new DALAsignacionDeRecursos();
                List<CredentialsDB> lCred = ade.GetAllCredencialesCiudad();

                if (!lCred.Any())
                {
                    return BadRequest();
                }

                List<Ciudad> allCiudades = new List<Ciudad>();
                foreach(CredentialsDB cred in lCred)
                {
                    Ciudad newCiu = new Ciudad()
                    {
                        Latitud = cred.Ciudad_Lat,
                        Longitud = cred.Ciudad_Lon,
                        Nombre = cred.NameCiudad
                    };

                    allCiudades.Add(newCiu);
                }

                if (!allCiudades.Any())
                {
                    return NotFound();
                }

                return Json(allCiudades);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error la buscar ciudades: " + e.Message);
                return InternalServerError();
            }
        }
        
        [HttpGet, Route("api/Ciudad/latitud/{latitud}/longitud/{longitud}")]
        public IHttpActionResult Get(double latitud, double longitud)
        {
            try
            {
                IDALAsignacionDeRecursos ADR = new DALAsignacionDeRecursos();
                CredentialsDB cred = new CredentialsDB();
                cred = ADR.GetCredencialesCiudad(latitud, longitud, ""); //Al pedir la ciudad el parametro nombre no hace nada
                string asd;
                asd = cred.NameCiudad;
                if (asd == "adsasd") {
                };
                if (cred == null)
                {
                    return NotFound();
                }

                Ciudad city = new Ciudad()
                {
                    Nombre = cred.NameCiudad,
                    Latitud = cred.Ciudad_Lat,
                    Longitud = cred.Ciudad_Lon
                };             

                return Json(city);                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar devolver ciudad: " + e.Message);
                return InternalServerError();
            }
        }
        
        [HttpPost, Route("api/Ciudad")]
        public IHttpActionResult Post(Ciudad nuevaCiudad)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IDALAsignacionDeRecursos nuevaCredencialCiudad = new DALAsignacionDeRecursos();
            CredentialsDB ciuCred = nuevaCredencialCiudad.GetCredencialesCiudad(nuevaCiudad.Latitud, nuevaCiudad.Longitud, nuevaCiudad.Nombre);

            if(ciuCred == null)
            {
                return NotFound();
            }

            return Json("Message: Se creo la ciudad");
        }

        //[HttpPut, Route("api/Ciudad")]
        //public IHttpActionResult Put(string nombre, Ciudad ciudad)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (nombre != ciudad.Nombre)
        //    {
        //        return BadRequest();
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //[HttpDelete, Route("api/Ciudad/latitud/{latitud}/longitud/{longitud}")]
        //public IHttpActionResult Delete(double latitud, double longitud)
        //{
        //    GetById, si no lo encuentro:
        //    if (cambioAlcance == null)
        //    {
        //        return NotFound();
        //    }

        //    Sistema de control de borrado
        //    if (CambioAlcanceApi.CanDelete(DC, id))
        //    {
        //        cambioAlcance.Deleted = true;
        //        CambioAlcanceApi.Update(DC, cambioAlcance);
        //        DeleteTareas(cambioAlcance.ID);

        //        return Ok(new DeleteResult
        //        {
        //            Success = true,
        //            Message = "Se ha eliminado con éxito el Cambio de Alcance."
        //        });
        //    }
        //    else
        //    {
        //        return Ok(new DeleteResult
        //        {
        //            Success = false,
        //            Message = "No se puede eliminar el Cambio de Alcance por que existen horas cargadas a alguna de sus tareas."
        //        });
        //    }
        //    return Ok();
        //}
    }
}
