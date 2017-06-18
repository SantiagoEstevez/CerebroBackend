using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerebro14.Services
{
    public static class CiudadHelper
    {
        public static CredentialsDB GetMockCredentials()
        {
            return new CredentialsDB()
            {
                AddressServerDb = "ds028540.mlab.com",
                NameDbM = "cerebro201701",
                NameDbSQL = "Ciudad01",
                PassDb = "5h5thg5@tgdhfGhuiOu",
                PortServerDb = 28540,
                UserDb = "AdminDB"
            };
        }
    
        public static string CreateToken24hrs()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();            
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }

        public static List<TipoSensor> TipoSensoresCiudad(double latitud = 0, double longitud = 0)
        {
            List<TipoSensor> lTipoSensores = new List<TipoSensor>();
            
            lTipoSensores.Add(new TipoSensor() { nombre = "Agua" });
            lTipoSensores.Add(new TipoSensor() { nombre = "Fuego" });
            lTipoSensores.Add(new TipoSensor() { nombre = "Tierra" });
            lTipoSensores.Add(new TipoSensor() { nombre = "Aire" });
            lTipoSensores.Add(new TipoSensor() { nombre = "Avatar" });
            lTipoSensores.Add(new TipoSensor() { nombre = "Nacion del fuego" });
            lTipoSensores.Add(new TipoSensor() { nombre = "Death star" });      

            return lTipoSensores;
        }
    }
}