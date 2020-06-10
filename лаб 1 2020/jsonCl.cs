using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб_1_2020
{
    public class films
    {
        public int id_film;
        public string avtor;
        public string nazvanie;
        public string annotacia;
        public string strana;
        public int god;
        public string zhanr;
    }
    public class users
    {
        public int id_user;
        public string login;
        public string password;
        public string data;
        public int role;
    }
    public class roles
    {
        public int id_role;
        public string name;
        public int lvl;
    }
}
