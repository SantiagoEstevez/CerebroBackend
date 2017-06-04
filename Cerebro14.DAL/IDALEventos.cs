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
        void AddEvent(Event e, CredentialsDB creden);

        bool ExistEventByID(double Lat, double Lon, CredentialsDB creden);

        void DeleteUser(double Lat, double Lon, CredentialsDB creden);

    }
}
