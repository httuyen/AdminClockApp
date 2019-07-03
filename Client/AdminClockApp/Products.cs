using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClockApp
{
    class Products
    {
        public int id { get; set; }//id product
        public int id_category { get; set; }//id _categories
        public String title { get; set; }
        public String detail { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public Products (string title,string detail,string price,string image, int id_category,int id)
        {
            this.id = id;
            this.title = title;
            this.detail = detail;
            this.price = price;
            this.image = image;
            this.id_category = id_category;
        }
        
    }
}
