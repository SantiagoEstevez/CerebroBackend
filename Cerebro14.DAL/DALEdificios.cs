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

        public void AddEdificiot(Edificio e, CredentialsDB creden) {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            TABedificios _dbEdi;

            _dbEdi = new TABedificios();

            _dbEdi.nombre = e.Name;
            _dbEdi.ID_Lat = e.Latitude;
            _dbEdi.ID_Lon = e.Longitude;

            db.TABedificios.Add(_dbEdi);
            db.SaveChanges();

        }

        public bool ExistEdificioByID(double Lat, double Lon, CredentialsDB creden) {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            return db.TABedificios.Any(e => (e.ID_Lat == Lat) && (e.ID_Lon == Lon));
        }

        public void DeleteEdificio(double Lat, double Lon, CredentialsDB creden) {

        }
    }
}
