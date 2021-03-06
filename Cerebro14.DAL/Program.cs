﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;
using Cerebro14.DAL.Mongodb;
using Cerebro14.Model.SensorTypes;
using System.Threading;
using System.Diagnostics;

namespace Cerebro14.DAL
{
    public class Sensores
    {
        private CredentialsDB creden = new CredentialsDB{

            AddressServerDb = "ds028540.mlab.com",
            NameDbM = "cerebro201701",
            NameDbSQL = "Ciudad01",
            PassDb = "5h5thg5@tgdhfGhuiOu",
            PortServerDb = 28540,
            UserDb = "AdminDB",
            NameCiudad = "mongolin",
            Ciudad_Lat = 100,
            Ciudad_Lon = 101
        };

        private CredentialsDB creden2 = new CredentialsDB {

            AddressServerDb = "ds163301.mlab.com",
            NameDbM = "cerebro201702",
            NameDbSQL = "Ciudad02",
            PassDb = "5h5thg5@tgdhfGhuiOu",
            PortServerDb = 63301,
            UserDb = "AdminDB",
            NameCiudad = "mongolin2",
            Ciudad_Lat = 100,
            Ciudad_Lon = 101
        };

        public void Ciudad_1_sensor_tipo_1()
        {

            while (Stop_C1_S1)
            {
                DataSensor d1 = new DataSensor();
                Random rnd = new Random();
                d1.dato = rnd.Next(10, 30);
                d1.diayHora = DateTime.Now;
                d1.Latitude = 1500;
                d1.Longitude = 1000;
                IDALdatosSensores mondb = new DALdatosSensores();
                mondb.AddDataSensor(d1, creden);
                Thread.Sleep(5000);
            };
        }
        public void Ciudad_1_sensor_tipo_2()
        {

            while (Stop_C1_S2)
            {
                DataSensor d1 = new DataSensor();
                Random rnd = new Random();
                d1.dato = rnd.Next(10, 30);
                d1.diayHora = DateTime.Now;
                d1.Latitude = 2500;
                d1.Longitude = 2000;
                IDALdatosSensores mondb = new DALdatosSensores();
                mondb.AddDataSensor(d1, creden);
                Thread.Sleep(5000);
            };
        }
        public void Ciudad_1_sensor_tipo_3()
        {

            while (Stop_C1_S3)
            {
                DataSensor d1 = new DataSensor();
                Random rnd = new Random();
                d1.dato = rnd.Next(10, 30);
                d1.diayHora = DateTime.Now;
                d1.Latitude = 3500;
                d1.Longitude = 3000;
                IDALdatosSensores mondb = new DALdatosSensores();
                mondb.AddDataSensor(d1, creden);
                Thread.Sleep(5000);
            };
        }
        public void Ciudad_2_sensor_tipo_1()
        {

            while (Stop_C2_S1)
            {
                DataSensor d1 = new DataSensor();
                Random rnd = new Random();
                d1.dato = rnd.Next(30, 100);
                d1.diayHora = DateTime.Now;
                d1.Latitude = 1500;
                d1.Longitude = 1000;
                IDALdatosSensores mondb = new DALdatosSensores();
                mondb.AddDataSensor(d1, creden);
                Thread.Sleep(5000);
            };
        }
        public void Ciudad_2_sensor_tipo_2()
        {

            while (Stop_C2_S2)
            {
                DataSensor d1 = new DataSensor();
                Random rnd = new Random();
                d1.dato = rnd.Next(30, 100);
                d1.diayHora = DateTime.Now;
                d1.Latitude = 2500;
                d1.Longitude = 2000;
                IDALdatosSensores mondb = new DALdatosSensores();
                mondb.AddDataSensor(d1, creden);
                Thread.Sleep(5000);
            };
        }
        public void Ciudad_2_sensor_tipo_3()
        {

            while (Stop_C2_S3)
            {
                DataSensor d1 = new DataSensor();
                Random rnd = new Random();
                d1.dato = rnd.Next(30, 100);
                d1.diayHora = DateTime.Now;
                d1.Latitude = 3500;
                d1.Longitude = 3000;
                IDALdatosSensores mondb = new DALdatosSensores();
                mondb.AddDataSensor(d1, creden);
                Thread.Sleep(5000);
            };
        }

        public void S_C1_S1()
        {
            Stop_C1_S1 = false;
        }
        public void C_C1_S1()
        {
            Stop_C1_S1 = true;
        }

        public void S_C1_S2()
        {
            Stop_C1_S2 = false;
        }
        public void C_C1_S2()
        {
            Stop_C1_S2 = true;
        }

        public void S_C1_S3()
        {
            Stop_C1_S3 = false;
        }
        public void C_C1_S3()
        {
            Stop_C1_S3 = true;
        }

        public void S_C2_S1()
        {
            Stop_C2_S1 = false;
        }
        public void C_C2_S1()
        {
            Stop_C2_S1 = true;
        }

        public void S_C2_S2()
        {
            Stop_C2_S2 = false;
        }
        public void C_C2_S2()
        {
            Stop_C2_S2 = true;
        }
        public void S_C2_S3()
        {
            Stop_C2_S3 = false;
        }
        public void C_C2_S3()
        {
            Stop_C2_S3 = true;
        }
        private volatile bool Stop_C1_S1 = true;
        private volatile bool Stop_C1_S2 = true;
        private volatile bool Stop_C1_S3 = true;

        private volatile bool Stop_C2_S1 = true;
        private volatile bool Stop_C2_S2 = true;
        private volatile bool Stop_C2_S3 = true;

    }
    class Program
    {

        static void Main(string[] args)
        {
            Sensores msg = new Sensores();
            Thread th1 = new Thread(new ThreadStart(msg.Ciudad_1_sensor_tipo_1));
            Thread th2 = new Thread(new ThreadStart(msg.Ciudad_1_sensor_tipo_2));
            Thread th3 = new Thread(new ThreadStart(msg.Ciudad_1_sensor_tipo_3));

            Thread th1C = new Thread(new ThreadStart(msg.Ciudad_2_sensor_tipo_1));
            Thread th2C = new Thread(new ThreadStart(msg.Ciudad_2_sensor_tipo_2));
            Thread th3C = new Thread(new ThreadStart(msg.Ciudad_2_sensor_tipo_3));
            bool seguir = true;
            string s;
            Console.WriteLine("Bienvenid@ precione S/s para salir");
            Console.WriteLine("Precione del 1 al 3 para activar el envio de datos en modo normal");
            Console.WriteLine("Precione del c1 al c3 para activar el envio de datos en modo caos");
            /*
                     CredentialsDB creden = new CredentialsDB
                    {

                        AddressServerDb = "ds028540.mlab.com",
                        NameDbM = "cerebro201701",
                        NameDbSQL = "Ciudad01",
                        PassDb = "5h5thg5@tgdhfGhuiOu",
                        PortServerDb = 28540,
                        UserDb = "AdminDB",
                        NameCiudad = "mongolin",
                        Ciudad_Lat = 100,
                        Ciudad_Lon = 101
                    };

         CredentialsDB creden2 = new CredentialsDB
        {

            AddressServerDb = "ds163301.mlab.com",
            NameDbM = "cerebro201702",
            NameDbSQL = "Ciudad02",
            PassDb = "5h5thg5@tgdhfGhuiOu",
            PortServerDb = 63301,
            UserDb = "AdminDB",
            NameCiudad = "mongolin2",
            Ciudad_Lat = 100,
            Ciudad_Lon = 101
        };

        IDALAsignacionDeRecursos coso = new DALAsignacionDeRecursos();
            coso.SetCredencialesCiudad(creden2, "");
            coso.SetCredencialesCiudad(creden, "");
            */
            while (seguir)
            {


             s = Console.ReadLine();


                if ( s == "S" || s == "s"){

                    msg.S_C1_S1();
                    msg.S_C1_S2();
                    msg.S_C1_S3();
                    msg.S_C2_S1();
                    msg.S_C2_S2();
                    msg.S_C2_S3();
                    seguir = false;
                }


                if (s == "1"){

                    msg.S_C2_S1();
                    msg.C_C1_S1();
                    if (!th1.IsAlive)
                    {
                        th1 = new Thread(new ThreadStart(msg.Ciudad_1_sensor_tipo_1));
                        th1.Start();
                        Console.Write("Iniciando sensor 1 en ciudad 1 modo normal");
                    }
                }

                if (s == "2")
                {
                    msg.S_C2_S2();
                    msg.C_C1_S2();
                    if (!th2.IsAlive)
                    {
                        th2 = new Thread(new ThreadStart(msg.Ciudad_1_sensor_tipo_2));
                        th2.Start();
                        Console.Write("Iniciando sensor 2 en ciudad 1 modo normal");
                    }

                }

                if (s == "3")
                {
                    msg.S_C2_S3();
                    msg.C_C1_S3();
                    if (!th3.IsAlive)
                    {
                        th3 = new Thread(new ThreadStart(msg.Ciudad_1_sensor_tipo_3));
                        th3.Start();
                        Console.Write("Iniciando sensor 3 en ciudad 1 modo normal");
                    }

                }


                if (s == "c1")
                {
                    msg.S_C1_S1();
                    msg.C_C2_S1();
                    if (!th1C.IsAlive)
                    {
                        th1C = new Thread(new ThreadStart(msg.Ciudad_2_sensor_tipo_1));
                        th1C.Start();
                        Console.Write("Iniciando sensor 1 en ciudad 1 modo caos");
                    }

                }

                if (s == "c2")
                {
                    msg.S_C1_S2();
                    msg.C_C2_S2();
                    if (!th2C.IsAlive)
                    {
                        th2C = new Thread(new ThreadStart(msg.Ciudad_2_sensor_tipo_2));
                        th2C.Start();
                        Console.Write("Iniciando sensor 2 en ciudad 1 modo caos");
                    }

                }

                if (s == "c3")
                {
                    msg.S_C1_S3();
                    msg.C_C2_S3();
                    if (!th3C.IsAlive)
                    {
                        th3C = new Thread(new ThreadStart(msg.Ciudad_2_sensor_tipo_3));
                        th3C.Start();
                        Console.Write("Iniciando sensor 3 en ciudad 1 modo caos");
                    }

                }

                if (s == "patapalo") {

                    var prs = new ProcessStartInfo("iexplore.exe");
                    prs.Arguments = "https://www.youtube.com/watch?v=1-aDtpk5860";
                    Process.Start(prs);
                }
            }

        }
    }
}
            /*
            //string C2 = "Ciudad02", C3 = "Ciudad03" ,C1 = "Ciudad01";

            CredentialsDB C1 = new CredentialsDB();
            CredentialsDB C2 = new CredentialsDB();
            CredentialsDB C3 = new CredentialsDB();
            C1.NameDbSQL = "Ciudad01";
            C2.NameDbSQL = "Ciudad02";
            C3.NameDbSQL = "Ciudad03";

            IDALUsuarios intface;
            intface = new DALUsuario();

            IDALEdificios intedif;

            intedif = new DALEdificios();
            //no ahi edificio asi que probe con evento es lo msomo
            Edificio e1, e2;
            e1 = new Edificio();
            e2 = new Edificio();

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



            //intedif.AddEdificiot(e1, C1);
            // intedif.AddEdificiot(e2, C1);

            //intface.AddUser(usu1, C1);
            //intface.AddUser(usu2, C1);
            // intface.AddUser(usu3, C1);


            List<User> listusu;
            //listusu = intface.GetAllUserLivingIn(150006,200006, C1);
            listusu = intface.GetAllUser(C1);


            IDALEdificios edi = new DALEdificios();

            if (edi.ExistEdificioByID(150006, 200006, C1)){

                Console.Write("**MAL**");

                Console.WriteLine();

            }
            else
            {
                Console.Write("**BIEN**");

                Console.WriteLine();

            }

            foreach (var iter in listusu) {

                Console.Write(iter.Email);
                Console.Write("        *********     ");
            };

            CredentialsDB creden = new CredentialsDB();
            creden.AddressServerDb = "ds028540.mlab.com";
            creden.NameDbM = "cerebro201701";
            creden.NameDbSQL = "Ciudad01";
            creden.PassDb = "5h5thg5@tgdhfGhuiOu";
            creden.PortServerDb = 28540;
            creden.UserDb = "AdminDB";

            creden.NameCiudad = "mongolin";
            creden.Ciudad_Lat = 100;
            creden.Ciudad_Lon = 101;

            IDALAsignacionDeRecursos cred = new DALAsignacionDeRecursos();

           

            CredentialsDB creden2 = new CredentialsDB();
            creden2.AddressServerDb = "ds163301.mlab.com";
            creden2.NameDbM = "cerebro201702";
            creden2.NameDbSQL = "Ciudad02";
            creden2.PassDb = "5h5thg5@tgdhfGhuiOu";
            creden2.PortServerDb = 63301;
            creden2.UserDb = "AdminDB";

            creden2.NameCiudad = "mongolin2";
            creden2.Ciudad_Lat = 100;
            creden2.Ciudad_Lon = 101;

            IDALAsignacionDeRecursos coso = new DALAsignacionDeRecursos();
            coso.SetCredencialesCiudad(creden2, "mongolin2");
            cred.SetCredencialesCiudad(creden, "sdf");

            CredentialsDB creden1test = new CredentialsDB();
           // creden1test = coso.GetCredencialesCiudad(100, 101, "mongolin");
            Console.Write("**********");
           // Console.Write(creden1test.NameDbM);
            Console.Write("**********");
            
            DataSensor d1, d2, d3;
            d1 = new DataSensor();
            d2 = new DataSensor();
            d3 = new DataSensor();

            d1.dato = 10;
            d1.diayHora = DateTime.Now;
            d1.Latitude = 12500;
            d1.Longitude = 14000;

            d2.dato = 30;
            d2.diayHora = DateTime.Now;
            d2.Latitude = 12000;
            d2.Longitude = 15000;

            d3.dato = 40;
            d3.diayHora = DateTime.Now;
            d3.Latitude = 15000;
            d3.Longitude = 12000;



            IDALdatosSensores mondb = new DALdatosSensores();

            mondb.AddDataSensor(d1,creden);
            mondb.AddDataSensor(d2, creden);
            mondb.AddDataSensor(d3, creden);



            Console.Write("**********" + DateTime.Now + "**********");


            List<DataSensor> listDaS;
            listDaS = mondb.GetAllDataSensor(12500, 14000,creden);
            
            foreach (var iter in listDaS)
            {



                Console.Write("DATO**");
                Console.Write(iter.dato);
                Console.Write("FECHA**");
                Console.Write(iter.diayHora);
                Console.Write("LAT**");
                Console.Write(iter.Latitude);
                Console.Write("LON**");
                Console.Write(iter.Longitude);
                Console.WriteLine();
                
            };

            DataSource s1, s2, s3,ss1,ss2,ss3;
            s1 = new SensorTemperature();
            s2 = new SensorTemperature();
            s3 = new SensorTemperature();
            s1.Latitude = 1001;
            s1.Longitude = 101;
            s1.name = "sensor 1";
            s1.Tipo = "SensorTemperature";

            s2.Latitude = 1002;
            s2.Longitude = 102;
            s2.name = "sensor 2";
            s2.Tipo = "SensorTemperature";

            s3.Latitude = 1003;
            s3.Longitude = 103;
            s3.name = "sensor 3";
            s3.Tipo = "SensorTemperature";

            IDALsensor weaSensor = new DALsensor();
            //weaSensor.AddSensor(s1, creden);
            //weaSensor.AddSensor(s2, creden);
            //weaSensor.AddSensor(s3, creden);

            Console.Write(weaSensor.GetSensorByID(1002,102, creden).name);


            //asignacion_de_recursosEntities dbr = new asignacion_de_recursosEntities();

            //dbr.TABCiudades.


            Console.Read();
        } 



    }
}
*/