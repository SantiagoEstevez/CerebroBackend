using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    abstract class DataSource
    {
        public int ID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

    }
}
