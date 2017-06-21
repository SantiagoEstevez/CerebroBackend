using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    public class DALAcciones:IDALAcciones
    {
        public void CreateAction(string IDUser, double Lat, double Lon, int tipo, string param, CredentialsDB creden) {

            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                //CiudadEntities db = new CiudadEntities();

                TABacciones _dbAcc;
                _dbAcc = new TABacciones();
                _dbAcc.FK_email_usu = IDUser;
                _dbAcc.FK_Eve_Lat = Lat;
                _dbAcc.FK_Eve_Lon = Lon;
                _dbAcc.parametros = param;
                _dbAcc.tipo = tipo;
                db.TABacciones.Add(_dbAcc);
                db.SaveChanges();
            }

        }

        public void AddAction(Accion a, CredentialsDB creden) {

            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                TABacciones _dbAcc;
                _dbAcc = new TABacciones();

                _dbAcc.parametros = a.Parametro;
                _dbAcc.tipo = a.Tipo;

                db.TABacciones.Add(_dbAcc);
                db.SaveChanges();
            }
        }

        public List<User> GetAllUserFromEvent(double Lat, double Lon, CredentialsDB creden) {

            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                TABacciones _dbAcc;
                _dbAcc = new TABacciones();

                var Usuarios = from u in db.TABacciones
                               where (u.FK_Eve_Lat == Lat && u.FK_Eve_Lon == Lon)
                               select u;

                List<User> lista = new List<User>();

                if (Usuarios != null)
                {
                    foreach (var _usu in Usuarios)
                    {

                        TABusuarios _usuasd = db.TABusuarios.Find(_usu.FK_email_usu);

                        User usu = new User();

                        usu.Birthdate = _usuasd.fechaN;
                        usu.CI = _usuasd.cedula;
                        usu.Email = _usuasd.email;
                        usu.Lastname = _usuasd.apellido;
                        usu.Lat_edicicio = _usuasd.FK_Edi_Lat;
                        usu.Lon_edicicio = _usuasd.FK_Edi_Lon;
                        usu.Name = _usuasd.nombre;
                        usu.Password = _usuasd.pass;
                        usu.Phone = _usuasd.telefono;
                        usu.Username = _usuasd.username;
                        lista.Add(usu);

                    }
                }

                return lista;
            }
        }

        public List<Event> GetAllEventsFromUser(string IDUser, CredentialsDB creden) {

            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                TABacciones _dbAcc;
                _dbAcc = new TABacciones();

                var Usuarios = from u in db.TABacciones
                               where (u.FK_email_usu == IDUser)
                               select u;

                List<Event> lista = new List<Event>();

                if (Usuarios != null)
                {
                    foreach (var _usu in Usuarios)
                    {
                        var eventoo = db.TABeventos
                            .Where(u => u.ID_Lat == _usu.FK_Eve_Lat && u.ID_Lon == _usu.FK_Eve_Lon)
                            .First();


                        Event usu = new Event();

                        usu.Latitude = eventoo.ID_Lat;
                        usu.Longitude = eventoo.ID_Lon;
                        usu.Name = eventoo.nombre;

                        lista.Add(usu);

                    }
                }
                return lista;
            }
        }

        public Accion GetAcctionFromUserEvent(string IDUser, double Lat, double Lon, CredentialsDB creden) {

            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                TABacciones _dbAcc;
                _dbAcc = new TABacciones();

                var _acction = from a in db.TABacciones
                               where (a.FK_Eve_Lat == Lat && a.FK_Eve_Lon == Lon && a.FK_email_usu == IDUser)
                               select a;

                TABacciones _ac;
                _ac = _acction.First();
                Accion ac = null;

                if (_ac != null)
                {

                    ac = new Accion();
                    ac.Parametro = _ac.parametros;
                    ac.Tipo = _ac.tipo;
                }

                return ac;
            }
        }

        public List<Accion> GetAllAcctions(CredentialsDB creden) {

            //CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            using (CiudadEntities db = new CiudadEntities(creden.NameDbSQL))
            {
                List<Accion> lista = new List<Accion>();
                foreach (var item in db.TABacciones.ToList())
                {
                    Accion acc = new Accion();
                    acc.Parametro = item.parametros;
                    acc.Tipo = item.tipo;
                    lista.Add(acc);
                }
                return lista;
            }
        }

        public void DeleteActionFromEvent(double Lat, double Lon, CredentialsDB creden) {



        }

        public void DeleteActionFromUser(string IDUser, CredentialsDB creden) {



        }

        public Accion GetAccion(int idEvento, int idUser, CredentialsDB creden)
        {
            throw new NotImplementedException();
        }

        public void DeleteAction(int idEvento, int idUser, CredentialsDB creden)
        {
            throw new NotImplementedException();
        }



        public void AddActionToEvent(Accion accion, double eventoLatitud, double eventoLongitud, CredentialsDB ciudad)
        {
            using (CiudadEntities db = new CiudadEntities(ciudad.NameDbSQL))
            {
                TABacciones newAccion = new TABacciones()
                {
                    id = 0,
                    FK_Eve_Lat = eventoLatitud,
                    FK_Eve_Lon = eventoLongitud,
                    FK_email_usu = accion.usuario.ToString(),
                    parametros = accion.Parametro,
                    tipo = accion.Tipo
                };

                db.TABacciones.Add(newAccion);
                db.SaveChanges();
            }
        }
    }
}
