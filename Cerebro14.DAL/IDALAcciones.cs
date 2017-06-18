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
        //void CreateAction(string IDUser, double Lat, double Lon, int tipo , string param, CredentialsDB creden);

        void AddAction(Accion a, CredentialsDB creden);

        Accion GetAccion(int idEvento, int idUser, CredentialsDB creden);

        //List<User> GetAllUserFromEvent(int idAccion, CredentialsDB creden);

        //List<Event> GetAllEventsFromUser(string idUser, CredentialsDB creden);

        //Accion GetAcctionFromUserEvent(string idUser, double Lat, double Lon, CredentialsDB creden);

        List<Accion> GetAllAcctions(CredentialsDB creden);

        void DeleteAction(int idEvento, int idUser, CredentialsDB creden);

        //void DeleteActionFromUser(int , CredentialsDB creden);

    }
}
