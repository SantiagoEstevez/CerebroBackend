using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    class City
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Event> Events { get; set; }
        //public IEnumerable<Building> Buildings { get; ser; }
        public IEnumerable<DataSource> DataSources { get; set; }
    }
}
