using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cerebro14.DAL;

namespace Cerebro14.Services.Controllers
{
    public class AccionController : ApiController
    {

        [HttpPost, Route("api/Accion")]
        public IHttpActionResult AgregarAccionAEvento(Accion newAction, Event toEvent, Ciudad inCity)
        {
            try
            {
                IDALAsignacionDeRecursos DBCiudades = new DALAsignacionDeRecursos();
                IDALEventos DBEventos = new DALEventos();
                IDALAcciones DBAcciones = new DALAcciones();

                CredentialsDB inCityCred = DBCiudades.GetCredencialesCiudad(inCity.Latitud, inCity.Longitud, inCity.Nombre);

                DBAcciones.AddActionToEvent(newAction, toEvent.Latitude, toEvent.Longitude, inCityCred);

                return Json("Message:exito");
            }
            catch(Exception e)
            {
                Console.WriteLine("No se pudo agregar la accion: " + e.Message);
                return InternalServerError();
            }            
        }
    }
}
