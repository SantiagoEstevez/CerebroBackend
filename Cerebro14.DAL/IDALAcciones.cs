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
        void CreateAction(string IDUser, double Lat, double Lon, int tipo , string param,string ciud);

        void AddAction(Action a, string ciud);

        List<User> GetAllUserFromEvent(double Lat, double Lon, string ciu);

        List<Event> GetAllEventsFromUser(string IDUser, string ciu);

        void DeleteActionFromEvent(double Lat, double Lon, string ciud);

        void DeleteActionFromUser(string IDUser, string ciu);

    }
}
