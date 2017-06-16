using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    public interface IDALEventoSensor
    {
        void CreateAction(double Lat_event, double Lon_event, double Lat_sen, double Lon_sen, double umbral,  CredentialsDB creden);

        List<Event> GetAllEventFromSensor(double Lat_sen, double Lon_sen, CredentialsDB creden);

        List<DataSource> GetAllSensorFromEvent(double Lat_event, double Lon_event, CredentialsDB creden);

        double GetUmbralFromSensorEvent(double Lat_event, double Lon_event, double Lat_sen, double Lon_sen, CredentialsDB creden);
    }
}
