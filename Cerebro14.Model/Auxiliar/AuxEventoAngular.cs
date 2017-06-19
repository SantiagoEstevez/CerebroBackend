using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model.Auxiliar
{
    public class AuxEventoAngular
    {
        //Ciudad
        public string ciudad { get; set; }//Nombre
        public double cLatitude { get; set; }
        public double cLongitude { get; set; }

        //Zona
        public string Nombre { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radio { get; set; }
    }
}
