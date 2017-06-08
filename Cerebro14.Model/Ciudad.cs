using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    public class Ciudad
    {
        public string Nombre { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

        public CredentialsDB DatabaseInfo { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Edificio> Buildings { get; set; }
        public IEnumerable<DataSource> DataSources { get; set; }
    }
}
