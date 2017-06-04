using System;
using Cerebro14.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.DAL
{
    public interface IDALEventos
    {
        void AddEvent(Event e, string ciud);

        bool ExistEventByID(double Lat, double Lon, string ciud);

        void DeleteUser(double Lat, double Lon, string ciud);

    }
}
