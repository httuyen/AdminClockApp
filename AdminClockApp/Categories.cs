using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClockApp
{
    class Categories
    {
        public int id { get; set; }
        public string title { get; set; }
        public Categories(string title, int id)
        {
            this.title = title;
            this.id = id;
        }

    }
}
