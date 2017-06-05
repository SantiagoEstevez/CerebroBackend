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
            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            TABeventos _dbeve;
            _dbeve = new TABeventos();

            _dbeve.nombre = e.Name;
            _dbeve.ID_Lat = e.Latitude;
            _dbeve.ID_Lon = e.Longitude;

            db.TABeventos.Add(_dbeve);
            db.SaveChanges();
        }
            

        public bool ExistEventByID(double Lat, double Lon, CredentialsDB creden)
        {
            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            return db.TABeventos.Any(e => (e.ID_Lat == Lat) && (e.ID_Lon == Lon));
        }

        public void DeleteUser(double Lat, double Lon, CredentialsDB creden)
        {

        }
    }
}
