using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;
using Cerebro14.Model.SensorTypes;

namespace Cerebro14.DAL
{
    public class DALEventoSensor : IDALEventoSensor
    {
        public void CreateAction(double Lat_event, double Lon_event, double Lat_sen, double Lon_sen, double umbral, string tipo, CredentialsDB creden)
        {
            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                TABsensorEvento _EveSen = new TABsensorEvento();

                _EveSen.FK_Eveto_Lat = Lat_event;
                _EveSen.FK_Eveto_Lon = Lon_event;
                _EveSen.FK_Sensor_Lat = Lat_sen;
                _EveSen.FK_Sensor_Lon = Lon_sen;
                _EveSen.umbral = umbral;
                try
                {
                    db.TABsensorEvento.Add(_EveSen);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} ERROR: ya existe o se perdio la conexion :( ", e);
                }
            }
        }

        public List<Event> GetAllEventFromSensor(double Lat_sen, double Lon_sen, CredentialsDB creden)
        {
            // CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                var Eventoss = from u in db.TABsensorEvento
                               where (u.FK_Sensor_Lat == Lat_sen && u.FK_Sensor_Lon == Lon_sen)
                               select u;

                List<Event> lista = new List<Event>();

                if (Eventoss != null)
                {
                    foreach (var _eve in Eventoss)
                    {

                        var eventoo = db.TABeventos
                            .Where(u => u.ID_Lat == _eve.FK_Eveto_Lat && u.ID_Lon == _eve.FK_Eveto_Lon).First();

                        Event eve = new Event();

                        eve.Name = eventoo.nombre;
                        eve.Latitude = eventoo.ID_Lat;
                        eve.Longitude = eventoo.ID_Lon;

                        lista.Add(eve);

                    }
                }
                return lista;
            }
        }

        public List<DataSource> GetAllSensorFromEvent(double Lat_event, double Lon_event, CredentialsDB creden)
        {
            // CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                var DataSour = from u in db.TABsensorEvento
                               where (u.FK_Eveto_Lat == Lat_event && u.FK_Eveto_Lon == Lon_event)
                               select u;

                List<DataSource> lista = new List<DataSource>();

                if (DataSour != null)
                {
                    foreach (var _das in DataSour)
                    {

                        var sensorr = db.TABsensor
                                              .Where(u => u.ID_Sen_Lat == _das.FK_Sensor_Lat && u.ID_Sen_Lon == _das.FK_Sensor_Lon).First();

                        DataSource sen = new SensorTemperature();

                        sen.Latitude = sensorr.ID_Sen_Lat;
                        sen.Longitude = sensorr.ID_Sen_Lon;
                        sen.Tipo = sensorr.tipo;

                        lista.Add(sen);

                    }
                }
                return lista;
            }
        }

        public double GetUmbralFromSensorEvent(double Lat_event, double Lon_event, double Lat_sen, double Lon_sen, CredentialsDB creden)
        {
            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                var umbra = db.TABsensorEvento.Where(u => u.FK_Eveto_Lat == Lat_event && u.FK_Eveto_Lon == Lon_event && u.FK_Sensor_Lat == Lat_sen && u.FK_Sensor_Lon == Lon_sen).First();

                if (umbra != null)
                {
                    return umbra.umbral;
                }
                else
                {
                    return -999999999;
                }
            }
        }
    }
}
