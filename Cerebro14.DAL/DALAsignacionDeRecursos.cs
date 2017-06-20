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
        public List<CredentialsDB> GetAllCredencialesCiudad()
        {
            using (CiudadEntities dbr = new CiudadEntities("Ciudad01"))
            {
                var Ciudad = from c in dbr.TABCiudades
                             where (c.RecursoLibre == 1.0)
                             select c;

                List<CredentialsDB> lista = new List<CredentialsDB>();

                foreach (var _ciud in Ciudad)
                {
                    CredentialsDB cred = new CredentialsDB();
                    cred.AddressServerDb = _ciud.AddressServerDb;
                    cred.Ciudad_Lat = _ciud.ID_Ciu_Lat;
                    cred.Ciudad_Lon = _ciud.ID_Ciu_Lon;
                    cred.NameCiudad = _ciud.NameCiudade;
                    cred.NameDbM = _ciud.NameDbM;
                    cred.NameDbSQL = _ciud.NameDbSQL;
                    cred.PassDb = _ciud.PassDb;
                    cred.PortServerDb = _ciud.PortServerDb;
                    cred.UserDb = _ciud.UserDb;

                    lista.Add(cred);

                }
                return lista;

            }


        }
        public CredentialsDB GetCredencialesCiudad(double Lat, double Lon, string nom) {

            try
            {
                using (CiudadEntities dbr = new CiudadEntities("Ciudad01"))
                {
                    //CiudadEntities dbr;
                    //dbr  = new CiudadEntities("Ciudad01");

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
                                     where (c.RecursoLibre == 0.0)
                                     select c;


                        TABCiudades _nuevaCred, _ciud;
                        _nuevaCred = new TABCiudades();
                        TABCiudades aborrar;
                        _ciud = Ciudad.First();

                        _nuevaCred.AddressServerDb = _ciud.AddressServerDb;
                        _nuevaCred.RecursoLibre = 1.0;
                        _nuevaCred.ID_Ciu_Lat = Lat;
                        _nuevaCred.ID_Ciu_Lon = Lon;
                        _nuevaCred.NameCiudade = nom;
                        _nuevaCred.NameDbM = _ciud.NameDbM;
                        _nuevaCred.NameDbSQL = _ciud.NameDbSQL;
                        _nuevaCred.PassDb = _ciud.PassDb;
                        _nuevaCred.PortServerDb = _ciud.PortServerDb;
                        _nuevaCred.UserDb = _ciud.UserDb;

                        aborrar = dbr.TABCiudades.Find(_ciud.id);
                        dbr.TABCiudades.Add(_nuevaCred);
                        dbr.SaveChanges();

                        dbr.TABCiudades.Remove(aborrar);
                        dbr.SaveChanges();


                    }
                    return cred;
                }
            }
            catch(Exception e)
            {                
                return null;
            }
 
        }
        public void SetCredencialesCiudad(CredentialsDB cre, string nam)
        {
            using (CiudadEntities dbr = new CiudadEntities("Ciudad01"))
            {
                //CiudadEntities dbr;
                //dbr = new CiudadEntities("Ciudad01");

                TABCiudades _nuevaCred;
                _nuevaCred = new TABCiudades();

                _nuevaCred.AddressServerDb = cre.AddressServerDb;
                _nuevaCred.ID_Ciu_Lat = 0.0;
                _nuevaCred.ID_Ciu_Lon = 0.0;
                _nuevaCred.NameCiudade = cre.NameCiudad;
                _nuevaCred.NameDbM = cre.NameDbM;
                _nuevaCred.NameDbSQL = cre.NameDbSQL;
                _nuevaCred.PassDb = cre.PassDb;
                _nuevaCred.PortServerDb = cre.PortServerDb;
                _nuevaCred.RecursoLibre = 0.0;
                _nuevaCred.UserDb = cre.UserDb;

                dbr.TABCiudades.Add(_nuevaCred);
                dbr.SaveChanges();
            }
        }
    }
}
