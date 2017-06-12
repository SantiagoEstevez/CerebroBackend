using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;
using Cerebro14.DAL.Mongodb;
using Cerebro14.Model.SensorTypes;
using System.Threading;

namespace Cerebro14.DAL
{

    public class MagiaMagia
    {
        private CredentialsDB credenciales;

        public MagiaMagia(double lat, double lon, string ciuName)
        {

            IDALAsignacionDeRecursos magi = new DALAsignacionDeRecursos();

            CredentialsDB cred;

            cred = magi.GetCredencialesCiudad(lat, lon, ciuName);
            credenciales = cred; //coso
            Console.Write("Hola esta es la wea: ");
            Console.Write(credenciales.NameCiudad);
            Console.WriteLine();
            Console.Write("En el servidor SQL de: ");
            Console.Write(credenciales.NameDbSQL);
            Console.WriteLine();
            Console.Write("En el servidor Mongolin de: ");
            Console.Write(credenciales.NameDbM);
            Console.WriteLine();
        }
        public void magiausuarios()
        {
            IDALUsuarios intface;
            intface = new DALUsuario();

            List<User> lista; // = new List<User>();
            lista = intface.GetAllUser(credenciales);
            foreach (var iter in lista)
            {
                Console.WriteLine();
                Console.Write("Hola esta es la lista de usuarios en esa base de datos: ");
                Console.Write(credenciales.NameCiudad);
                Console.WriteLine();
                Console.Write(iter.Name);
                Console.Write(iter.Email);


            }
        }

        
    }
}
