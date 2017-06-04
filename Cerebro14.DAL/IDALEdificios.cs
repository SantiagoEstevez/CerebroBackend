using System;
using Cerebro14.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.DAL
{
    public interface IDALEdificios
    {
        void AddEdificiot(Event e, string ciud);

        bool EdificioEventByID(double Lat, double Lon, string ciud);

        void DeleteEdificio(double Lat, double Lon, string ciud);

    }
}