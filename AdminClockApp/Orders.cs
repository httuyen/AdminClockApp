using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClockApp
{
    class Orders
    {

        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
        public string datecreate { get; set; }
        public Orders (int id, string name, string email, string phonenumber, string address, string datecreate)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phonenumber = phonenumber;
            this.address = address;
            this.datecreate = datecreate;
        }
    }
}
