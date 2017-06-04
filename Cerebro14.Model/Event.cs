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

        //public IEnumerable<Action> Actions { get; set; }
        //public IEnumerable<DataSource> DataSources{get;set;}
    }
}
