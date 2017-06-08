using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    public class CredentialsDB
    {
        public int ID { get; set; }
        public string NameCiudad { get; set; }
        public double Ciudad_Lat { get; set; }
        public double Ciudad_Lon { get; set; }
        public string NameDbSQL { get; set; }

        public string UserDb { get; set; }
        public string PassDb { get; set; }
        public string NameDbM { get; set; }
        public string AddressServerDb { get; set; }
        public double PortServerDb { get; set; }
       
    }
}
