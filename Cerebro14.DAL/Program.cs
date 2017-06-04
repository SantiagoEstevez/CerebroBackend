using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            string C2 = "Ciudad02", C3 = "Ciudad03" ,C1 = "Ciudad01";

            IDALUsuarios intface;
            intface = new DALUsuario();

            IDALEdificios intedif;

            intedif = new DALEdificios();
            //no ahi edificio asi que probe con evento es lo msomo
            Event e1, e2;
            e1 = new Event();
            e2 = new Event();

            e1.Name = "inco";
            e1.Latitude = 150006;
            e1.Longitude = 200006;

            e2.Name = "Fing";
            e2.Latitude = 35000;
            e2.Longitude = 250000;



            User usu1, usu2, usu3;
            usu1 = new User();
            usu2 = new User();
            usu3 = new User();
            DateTime dia = new DateTime(1989,12,5);

            usu1.CI = "48563787";
            usu1.Email = "www.damian17@gmail.com";
            usu1.Lastname = "carancho";
            usu1.Name = "Damian";
            usu1.Password = "magiamagiamagia";
            usu1.Phone = "094202125";
            usu1.Username = "D4m14n";
            usu1.Lat_edicicio = 150006;
            usu1.Lon_edicicio = 200006;
            usu1.Birthdate = dia;

            usu2.CI = "48564387";
            usu2.Email = "Mitsuko@gmail";
            usu2.Lastname = "carancho";
            usu2.Name = "cosoCosoCoso";
            usu2.Password = "magiamagiamagia";
            usu2.Phone = "089202125";
            usu2.Username = "Mitsuko";
            usu2.Lat_edicicio = 35000;
            usu2.Lon_edicicio = 250000;
            usu2.Birthdate = dia;

            usu3.CI = "34353787";
            usu3.Email = "luffy17@gma";
            usu3.Lastname = "D";
            usu3.Name = "luffy";
            usu3.Password = "magiamagiamagia";
            usu3.Phone = "0456462125";
            usu3.Username = "luffy.D";
            usu3.Lat_edicicio = 150006;
            usu3.Lon_edicicio = 200006;
            usu3.Birthdate = dia;

            // intedif.AddEdificiot(e1, C1);
            // intedif.AddEdificiot(e2, C1);

            // intface.AddUser(usu1, C1);
            //  intface.AddUser(usu2, C1);
            //  intface.AddUser(usu3, C1);
            List<User> listusu;
            listusu = intface.GetAllUserLivingIn(150006,200006, C1);
            foreach (var iter in listusu) {

                Console.Write(iter.Email);
                Console.Write("        *********     ");
            };
            Console.Read();
        }
    }
}
