using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    public class DALEventos: IDALEventos
    {
        public void AddEvent(Event e, CredentialsDB creden)
        {
            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                TABeventos _dbeve;
                _dbeve = new TABeventos();

                _dbeve.nombre = e.Name;
                _dbeve.ID_Lat = e.Latitude;
                _dbeve.ID_Lon = e.Longitude;
                _dbeve.Radio = e.Radio;
                try
                {
                    db.TABeventos.Add(_dbeve);
                    db.SaveChanges();
                }
                catch (Exception ek)
                {
                    Console.WriteLine("{0} ERROR: ya existe o se perdio la conexion :( ", ek);
                }
            }
        }

        public List<Event> GetAllEvent(CredentialsDB creden) {
            try
            {
                using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
                {
                    List<Event> lista = new List<Event>();
                    foreach (var item in db.TABeventos.ToList())
                    {
                        Event acc = new Event();
                        acc.Name = item.nombre;
                        acc.Latitude = item.ID_Lat;
                        acc.Longitude = item.ID_Lon;
                        acc.Radio = item.Radio;
                        lista.Add(acc);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo devolver los eventos de la ciudad");
                return new List<Event>();
            }
        }

        public bool ExistEventByID(double Lat, double Lon, CredentialsDB creden)
        {
            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                return db.TABeventos.Any(e => (e.ID_Lat == Lat) && (e.ID_Lon == Lon));
            }
        }

        public void DeleteUser(double Lat, double Lon, CredentialsDB creden)
        {

        }

        public Event GetEvent(int idEvento, CredentialsDB creden)
        {
            throw new NotImplementedException();
        }
    }
}
