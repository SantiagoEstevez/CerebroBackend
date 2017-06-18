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
        public int Tipo { get; set; }
        public string Parametro { get; set; } //NroTelefono | Email | RutaServicio
        public User usuario { get; set; }
    }
}
