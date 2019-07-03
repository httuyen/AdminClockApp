using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClockApp
{
    class OrderDetail
    {
        public int id_order { get; set; } // id order
        public int product_id { get; set; } //id product
        public string price { get; set; }
        public int quantity { get; set; }
        //public virtual Orders Orders { get; set; }
        //public virtual Products Products { get; set; }
        public OrderDetail (int id_order, int product_id, string price,int quantity)
        {
            this.price = price;
            this.quantity = quantity;
            this.id_order= id_order;
            this.product_id = product_id;
        }
    }
}
