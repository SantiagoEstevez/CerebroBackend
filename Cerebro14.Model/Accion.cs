using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    public class Accion
    {
        public string ID { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Parametro { get; set; }
        public int Tipo { get; set; }
        public string EmailUsu { get; set; }
    }
}
