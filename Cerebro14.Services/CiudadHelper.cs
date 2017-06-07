using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerebro14.Services
{
    public static class CiudadHelper
    {
        public static CredentialsDB GetMockCredentials()
        {
            return new CredentialsDB()
            {
                AddressServerDb = "ds028540.mlab.com",
                NameDbM = "cerebro201701",
                NameDbSQL = "Ciudad01",
                PassDb = "5h5thg5@tgdhfGhuiOu",
                PortServerDb = 28540,
                UserDb = "AdminDB"
            };
        }
    }
}