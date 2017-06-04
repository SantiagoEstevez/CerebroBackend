using System;
using Cerebro14.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.DAL
{
    public interface IDALUsuarios
    {
        void AddUser(User usu, string ciud);

        User GetUserByID(string userID, string ciud);

        bool ExistUserByID(string userID, string ciud);

        void DeleteUser(string nom, string ciud);

        void UpdateUser(User usu, string ciud);

        List<User> GetAllUserLivingIn(double Lat, double Lon, string ciud);
    }
}
