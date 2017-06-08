using System;
using Cerebro14.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.DAL
{
    public interface IDALAcciones
    {
        void CreateAction(string IDUser, double Lat, double Lon, int tipo , string param, CredentialsDB creden);

        void AddAction(Accion a, CredentialsDB creden);

        List<User> GetAllUserFromEvent(double Lat, double Lon, CredentialsDB creden);

        List<Event> GetAllEventsFromUser(string IDUser, CredentialsDB creden);

        Accion GetAcctionFromUserEvent(string IDUser, double Lat, double Lon, CredentialsDB creden);

        List<Accion> GetAllAcctions(CredentialsDB creden);

        void DeleteActionFromEvent(double Lat, double Lon, CredentialsDB creden);

        void DeleteActionFromUser(string IDUser, CredentialsDB creden);

    }
}
