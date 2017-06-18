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

        public static TipoSensores TipoSensoresCiudad(double latitud = 0, double longitud = 0)
        {
            TipoSensores ret = new TipoSensores();
            ret.Tipos = new List<TipoSensor>();
            
            ret.Tipos.Add(new TipoSensor() { nombre = "Agua" };);
            ret.Tipos.Add(new TipoSensor() { nombre = "Fuego" });
            ret.Tipos.Add(new TipoSensor() { nombre = "Tierra" });
            ret.Tipos.Add(new TipoSensor() { nombre = "Aire" });
            ret.Tipos.Add(new TipoSensor() { nombre = "Avatar" });
            ret.Tipos.Add(new TipoSensor() { nombre = "Nacion del fuego" });
            ret.Tipos.Add(new TipoSensor() { nombre = "Death star" });      

            return ret;
        }
    }
}