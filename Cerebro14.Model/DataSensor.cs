using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cerebro14.Model
{
    public class DataSensor
    {
        public ObjectId id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime diayHora { get; set; }
        public double dato { get; set; }
    }
}
