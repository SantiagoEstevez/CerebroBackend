using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;
using Cerebro14.DAL.Mongodb;
using Cerebro14.Model.SensorTypes;

namespace Cerebro14.DAL
{
    public class DALAsignacionDeRecursos : IDALAsignacionDeRecursos
    {
        public CredentialsDB GetCredencialesCiudad(double Lat, double Lon,string nom) {

            CiudadEntities dbr;
            dbr  = new CiudadEntities("Ciudad01");
          
            CredentialsDB cred = new CredentialsDB();

            if (dbr.TABCiudades.Any(c => (c.ID_Ciu_Lat == Lat && c.ID_Ciu_Lon == Lon)))
            {
                var Ciudad = from c in dbr.TABCiudades
                               where (c.ID_Ciu_Lat == Lat && c.ID_Ciu_Lon == Lon)
                               select c;
                
                foreach (var _ciud in Ciudad)
                {
                    cred.AddressServerDb = _ciud.AddressServerDb;
                    cred.Ciudad_Lat = _ciud.ID_Ciu_Lat;
                    cred.Ciudad_Lon = _ciud.ID_Ciu_Lon;
                    cred.NameCiudad = _ciud.NameCiudade;
                    cred.NameDbM = _ciud.NameDbM;
                    cred.NameDbSQL = _ciud.NameDbSQL;
                    cred.PassDb = _ciud.PassDb;
                    cred.PortServerDb = _ciud.PortServerDb;
                    cred.UserDb = _ciud.UserDb;
                }                
            }
            else
            {
             var Ciudad = from c in dbr.TABCiudades
                        where (c.RecursoLibre == 0)
                         select c;

             bool unavez = true;

             foreach (var _ciud in Ciudad)
                {
                    if (unavez) {
                    unavez = false;

                        _ciud.RecursoLibre = 1;
                        _ciud.ID_Ciu_Lat = Lat;
                        _ciud.ID_Ciu_Lon = Lon;
                        _ciud.NameCiudade = nom;

        
                        dbr.TABCiudades.Add(_ciud);
                        dbr.SaveChanges();
                    }
                }

            }
            return cred;


        }
        public void SetCredencialesCiudad(CredentialsDB cre, string nam) {

            CiudadEntities dbr;
            dbr = new CiudadEntities("Ciudad01");

            TABCiudades _nuevaCred;
            _nuevaCred = new TABCiudades();

            _nuevaCred.AddressServerDb = cre.AddressServerDb;
            _nuevaCred.ID_Ciu_Lat = cre.Ciudad_Lat;
            _nuevaCred.ID_Ciu_Lon = cre.Ciudad_Lon;
            _nuevaCred.NameCiudade = cre.NameCiudad;
            _nuevaCred.NameDbM = cre.NameDbM;
            _nuevaCred.NameDbSQL = cre.NameDbSQL;
            _nuevaCred.PassDb = cre.PassDb;
            _nuevaCred.PortServerDb = cre.PortServerDb;
            _nuevaCred.RecursoLibre = 1.0;
            _nuevaCred.UserDb = cre.UserDb;

            dbr.TABCiudades.Add(_nuevaCred);
            dbr.SaveChanges();
        }
    }
}
