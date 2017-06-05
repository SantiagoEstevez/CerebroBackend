using System;
using System.Collections.Generic;
using Cerebro14.Model;
using Cerebro14.DAL.Model;
using Cerebro14.Model.SensorTypes;

namespace Cerebro14.DAL
{
    public class DALsensor : IDALsensor
    {
        public void AddSensor(DataSource d, CredentialsDB creden) {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            TABsensor _dbSen;
            _dbSen = new TABsensor();

            _dbSen.ID_Sen_Lat = d.Latitude;
            _dbSen.ID_Sen_Lon = d.Longitude;
            _dbSen.nombre = d.name;
            _dbSen.tipo = d.tipo;


            db.TABsensor.Add(_dbSen);
            db.SaveChanges();

        }
        
        public List<DataSource> GetAllSensor(CredentialsDB creden) {


            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            var Usuarios = db.TABsensor;
            List<DataSource> lista = new List<DataSource>();

            foreach (var _usu in Usuarios)
            {

                if (_usu.tipo != "magia")
                {
                    DataSource usu = new SensorTemperature();
                    usu.Latitude = _usu.ID_Sen_Lat;
                    usu.Longitude = _usu.ID_Sen_Lon;
                    usu.name = _usu.nombre;
                    usu.tipo = _usu.tipo;
 
                    lista.Add(usu);
                }
                
            }
            return lista;

        }

        public DataSource GetSensorByID(double Lat, double Lon, CredentialsDB creden) {

            return null;

        }
    }
}
