using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    class Ciudad
    {
        public string AddressServerDB { get; set; }
        public string NameDBMongo { get; set; }
        public string PassDB { get; set; }
        public string UserDB { get; set; }
        public int PortServerDB { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Event> Events { get; set; }
        //public IEnumerable<Building> Buildings { get; ser; }
        public IEnumerable<DataSource> DataSources { get; set; }
    }
}
