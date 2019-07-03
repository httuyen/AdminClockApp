using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClockApp
{
    class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }  
        public string email { get; set; }  
        public int phonenumber { get; set; }
        public string address { get; set; }
        public bool isAdmin { get; set; }
        public Users (string username, string password, string name, 
                      string email, int phonenumber, string address, bool isAdmin)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.email = email;
            this.phonenumber = phonenumber;
            this.address = address;
            this.isAdmin = isAdmin;
        }
    }
}
