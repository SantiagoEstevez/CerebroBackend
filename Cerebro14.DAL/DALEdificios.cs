using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    public class DALEdificios : IDALEdificios
    {

        public void AddEdificiot(Edificio ed, CredentialsDB creden) {

            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                TABedificios _dbEdi;

                _dbEdi = new TABedificios();

                _dbEdi.nombre = ed.Name;
                _dbEdi.ID_Lat = ed.Latitude;
                _dbEdi.ID_Lon = ed.Longitude;
                try
                {
                    db.TABedificios.Add(_dbEdi);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} ERROR: ya existe o se perdio la conexion :( ", e);
                }
            }
        }

        public bool ExistEdificioByID(double Lat, double Lon, CredentialsDB creden) {

            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                return db.TABedificios.Any(e => (e.ID_Lat == Lat) && (e.ID_Lon == Lon));
            }
        }

        public List<Edificio> GetAllEdificios(CredentialsDB creden)
        {
            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                List<Edificio> lista = new List<Edificio>();
                foreach (var item in db.TABedificios.ToList())
                {
                    Edificio acc = new Edificio();
                    acc.Name = item.nombre;
                    acc.Latitude = item.ID_Lat;
                    acc.Longitude = item.ID_Lon;
                    lista.Add(acc);
                }
                return lista;
            }
        }

        public void DeleteEdificio(double Lat, double Lon, CredentialsDB creden) {

        }
    }
}
