using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    public interface IDALAsignacionDeRecursos
    {
        CredentialsDB GetCredencialesCiudad(double Lat, double Lon,string nom);
        void SetCredencialesCiudad(CredentialsDB cre, string nam);
    }
}
