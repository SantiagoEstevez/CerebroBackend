using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL.Mongodb
{
    interface IDALdatosSensores
    {
        void AddDataSensor(DataSensor dataSe, CredentialsDB creden);
        void AddDataSensor(double Lat, double Lon, double dato,DateTime fecha, CredentialsDB creden);
        List<DataSensor> GetAllDataSensor(double Lat, double Lon, CredentialsDB creden);
    }
}
