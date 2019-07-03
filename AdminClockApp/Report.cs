using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClockApp
{
    class Report
    {
        public string caterogy { get; set; }
        public string tenSp { get; set; }
        public string detail { get; set; }
        public string price { get; set; }
        public int quantity { get; set; }
        public int priceOfOnly { get; set; }
        public int priceTotal { get; set; }

        public Report(string category, string tenSp, string detail, string price, int quantity,int priceOfOnly)
        {
            this.caterogy = category;
            this.tenSp = tenSp;
            this.detail = detail;
            this.price = price;
            this.quantity = quantity;
            this.priceOfOnly = priceOfOnly;
        }
    }
   
}
