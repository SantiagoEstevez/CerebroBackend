using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    public abstract class DataSource
    {
        public int ID { get; set; }
        public String name { get; set; }
        public string Tipo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Umbral { get; set; }
    }
}
