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
        void AddUser(User usu, CredentialsDB creden);

        User GetUserByID(string userID, CredentialsDB creden);

        bool ExistUserByID(string userID, CredentialsDB creden);

        void DeleteUser(string nom, CredentialsDB creden);

        void UpdateUser(User usu, CredentialsDB creden);

        List<User> GetAllUser(CredentialsDB creden);

        List<User> GetAllUserLivingIn(double Lat, double Lon, CredentialsDB creden);
    }
}
