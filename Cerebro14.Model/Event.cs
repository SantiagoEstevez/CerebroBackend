using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    public class Event
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radio { get; set; }

        public List<Action> Actions { get; set; }
        public List<DataSource> DataSources{ get; set; } //Tipos de sensores
        public List<User> Usuarios { get; set; }

        /*
        public Event GetAllTypeDataSourceinEvent(double latEvent, double lonEvent, string typeDataSource)
        {
            DataSource sensor = 
        }
        */
    }
}
