using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cerebro14.Model;
using Cerebro14.DAL.Model;

namespace Cerebro14.DAL
{
    public class DALUsuario : IDALUsuarios
    {


        public void AddUser(User usu, CredentialsDB creden) {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            TABusuarios _dbUsu;
            _dbUsu = new TABusuarios();

            _dbUsu.nombre = usu.Name;
            _dbUsu.apellido = usu.Lastname;
            _dbUsu.email = usu.Email;
            _dbUsu.cedula = usu.CI;
            _dbUsu.pass = usu.Password;
            _dbUsu.telefono = usu.Phone;
            _dbUsu.username = usu.Username;
            _dbUsu.fechaN = usu.Birthdate;
            _dbUsu.FK_Edi_Lat = usu.Lat_edicicio;
            _dbUsu.FK_Edi_Lon = usu.Lon_edicicio;

            db.TABusuarios.Add(_dbUsu);
            db.SaveChanges();

        }
        public bool ExistUserByID(string userID, CredentialsDB creden)
        {
            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            TABusuarios usu = db.TABusuarios.Find(userID);

            return !(usu == null);
        }
        public void DeleteUser(string nom, CredentialsDB creden) {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            TABusuarios usu = db.TABusuarios.Find(nom);
            db.TABusuarios.Remove(usu);
            db.SaveChanges();
        }

        public void UpdateUser(User usu, CredentialsDB creden) {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            TABusuarios _dbUsu = db.TABusuarios.Find(usu.Email);

            _dbUsu.nombre = usu.Name;
            _dbUsu.apellido = usu.Lastname;
            _dbUsu.email = usu.Email;
            _dbUsu.cedula = usu.CI;
            _dbUsu.pass = usu.Password;
            _dbUsu.telefono = usu.Phone;
            _dbUsu.username = usu.Username;
            _dbUsu.fechaN = usu.Birthdate;
            _dbUsu.FK_Edi_Lat = usu.Lat_edicicio;
            _dbUsu.FK_Edi_Lon = usu.Lon_edicicio;

            db.SaveChanges();


        }

        public List<User> GetAllUserLivingIn(double Lat, double Lon, CredentialsDB creden)
        {
            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            var Usuarios = from u in db.TABusuarios
                           where (u.FK_Edi_Lat == Lat && u.FK_Edi_Lon == Lon)
                           select u;

            List<User> lista = new List<User>();

            if (Usuarios != null)
            {
                foreach (var _usu in Usuarios)
                {
                    User usu = new User();

                    

                    usu.Birthdate = _usu.fechaN;
                    usu.CI = _usu.cedula;
                    usu.Email = _usu.email;
                    usu.Lastname = _usu.apellido;
                    usu.Lat_edicicio = _usu.FK_Edi_Lat;
                    usu.Lon_edicicio = _usu.FK_Edi_Lon;
                    usu.Name = _usu.nombre;
                    usu.Password = _usu.pass;
                    usu.Phone = _usu.telefono;
                    usu.Username = _usu.username;

                    lista.Add(usu);
                }
            }
            return lista;
        }
        public List<User> GetAllUser(CredentialsDB creden) {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);
            var Usuarios = db.TABusuarios;
            List<User> lista = new List<User>();

            foreach (var _usu in Usuarios)
            {
                User usu = new User();

                //usu = new User();

                usu.Birthdate = _usu.fechaN;
                usu.CI = _usu.cedula;
                usu.Email = _usu.email;
                usu.Lastname = _usu.apellido;
                usu.Lat_edicicio = _usu.FK_Edi_Lat;
                usu.Lon_edicicio = _usu.FK_Edi_Lon;
                usu.Name = _usu.nombre;
                usu.Password = _usu.pass;
                usu.Phone = _usu.telefono;
                usu.Username = _usu.username;

                lista.Add(usu);
            }
            return lista;

        }
        public User GetUserByID(string userID, CredentialsDB creden)
        {

            CiudadEntities db = new CiudadEntities(creden.NameDbSQL);

            TABusuarios _usu = db.TABusuarios.Find(userID);

            User usu = null;

            if (_usu != null)
            {

                usu = new User();

                usu.Birthdate = _usu.fechaN;
                usu.CI = _usu.cedula;
                usu.Email = _usu.email;
                usu.Lastname = _usu.apellido;
                usu.Lat_edicicio = _usu.FK_Edi_Lat;
                usu.Lon_edicicio = _usu.FK_Edi_Lon;
                usu.Name = _usu.nombre;
                usu.Password = _usu.pass;
                usu.Phone = _usu.telefono;
                usu.Username = _usu.username;

            }
            return usu;

        }
    }
}
