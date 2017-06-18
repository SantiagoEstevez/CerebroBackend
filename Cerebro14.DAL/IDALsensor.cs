using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    public interface IDALsensor
    {
        void AddSensor(DataSource d, CredentialsDB creden);

        DataSource GetSensor(int idSensor, CredentialsDB creden);

        List<DataSource> GetAllSensor(CredentialsDB creden);

        void DeleteSensor(int idSensor, CredentialsDB creden);
    }
}
