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
        void AddEdificiot(Edificio e, CredentialsDB creden);

        bool ExistEdificioByID(double Lat, double Lon, CredentialsDB creden);

        void DeleteEdificio(double Lat, double Lon, CredentialsDB creden);

    }
}