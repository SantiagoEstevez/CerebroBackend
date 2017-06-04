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

        public void AddEdificiot(Event e, string ciud) {

            CiudadEntities db = new CiudadEntities(ciud);
            TABedificios _dbEdi;

            _dbEdi = new TABedificios();

            _dbEdi.nombre = e.Name;
            _dbEdi.ID_Lat = e.Latitude;
            _dbEdi.ID_Lon = e.Longitude;

            db.TABedificios.Add(_dbEdi);
            db.SaveChanges();

        }

        public bool EdificioEventByID(double Lat, double Lon, string ciud) {

            return 5 == 2+3;
        }

        public void DeleteEdificio(double Lat, double Lon, string ciud) {

        }
    }
}
