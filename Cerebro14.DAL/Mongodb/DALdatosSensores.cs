using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Cerebro14.Model;

namespace Cerebro14.DAL.Mongodb
{
  
    public class DALdatosSensores : IDALdatosSensores
    {


        public void AddDataSensor(DataSensor dataSe, CredentialsDB creden)
        {

            var cred = MongoCredential.CreateCredential(creden.NameDbM, creden.UserDb, creden.PassDb);
            var sett = new MongoClientSettings
            {
                Server = new MongoServerAddress(creden.AddressServerDb, Convert.ToInt32(creden.PortServerDb)),
                Credentials = new List<MongoCredential> { cred }
            };
            var client = new MongoClient(sett);
            IMongoDatabase _db = null;
            _db = client.GetDatabase(creden.NameDbM);
            _db.GetCollection<DataSensor>("DataSensor").InsertOneAsync(dataSe);

        }


        public void AddDataSensor(double Lat, double Lon, double dato, DateTime fecha, CredentialsDB creden)
        {
            var cred = MongoCredential.CreateCredential(creden.NameDbM, creden.UserDb, creden.PassDb);
            var sett = new MongoClientSettings
            {
                Server = new MongoServerAddress(creden.AddressServerDb, Convert.ToInt32(creden.PortServerDb)),
                Credentials = new List<MongoCredential> { cred }
            };
            var client = new MongoClient(sett);
            IMongoDatabase _db = null;
            _db = client.GetDatabase(creden.NameDbM);

            DataSensor dataSe = new DataSensor();
            dataSe.dato = dato;
            dataSe.diayHora = fecha;
            dataSe.Latitude = Lat;
            dataSe.Longitude = Lon;


            _db.GetCollection<DataSensor>("DataSensor").InsertOneAsync(dataSe);
        }

        public List<DataSensor> GetAllDataSensor(double Lat, double Lon, CredentialsDB creden) {

            var cred = MongoCredential.CreateCredential(creden.NameDbM, creden.UserDb, creden.PassDb);
            var sett = new MongoClientSettings
            {
                Server = new MongoServerAddress(creden.AddressServerDb, Convert.ToInt32(creden.PortServerDb)),
                Credentials = new List<MongoCredential> { cred }
            };
            var client = new MongoClient(sett);
            IMongoDatabase _db = null;
            _db = client.GetDatabase(creden.NameDbM);
            var LisDataSen = _db.GetCollection<DataSensor>("DataSensor").Find(d => d.Latitude == Lat && d.Longitude == Lon).ToList();



            foreach (var iter in LisDataSen)
            { 
                DateTime iKnowThisIsUtc = iter.diayHora;
                DateTime runtimeKnowsThisIsUtc = DateTime.SpecifyKind(
                iKnowThisIsUtc,
                DateTimeKind.Utc);
                DateTime localVersion = runtimeKnowsThisIsUtc.ToLocalTime();
                iter.diayHora = localVersion;
            }

            return LisDataSen;
        }
        /*
        public void addDatoSensor(double Lat, double Lon, double data, string ciudad) {


            Event e = new Event();
            e.Latitude = Lat;
            e.Longitude = Lon;
            e.Name = ciudad;


            // mongodb://<AdminDB>:<5h5thg5@tgdhfGhuiOu>@ds028540.mlab.com:28540/cerebro201701


            var cred = MongoCredential.CreateCredential("cerebro201701", "AdminDB", "5h5thg5@tgdhfGhuiOu");
            var sett = new MongoClientSettings
            {
                Server = new MongoServerAddress("ds028540.mlab.com", 28540),
                Credentials = new List<MongoCredential> { cred }
            };
            var client = new MongoClient(sett);
            IMongoDatabase _db = null;
            _db = client.GetDatabase("cerebro201701");
           // _db.CreateCollection("coso");
            _db.GetCollection<Event>("coso").InsertOneAsync(e);

            var j =_db.GetCollection< Event >("coso").Find(c => c.Latitude == Lat && c.Longitude == Lon);
            Event g;
            g = j.FirstOrDefault();

            if (g == null) {

                Console.Write("********FUNCIONA ESO CREO************");
            }
            else
            {
               
                Console.Write(g.Name);
                Console.Write("***********************");
                Console.Write(g.Latitude);
                Console.Write("***********************");
                Console.Write(g.Longitude);
            }




            



            // db.GetCollection<Event>("Evento").InsertOneAsync(e);
            // var collection = database.GetCollection<BsonDocument>("bar");
        }
        */
    }
}
