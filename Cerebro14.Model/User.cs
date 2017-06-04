using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebro14.Model
{
    public class User
    {
        public string CI { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Lat_edicicio { get; set; }
        public double Lon_edicicio { get; set; }

        //public IEnumerable<Actions> _actions;
        //public IEnumerable<Events> _events;
        //public City _city;
        //public IEnumerable<Building> _building;
    }
}
