using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class OdersDetail
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int id_order { get; set; } // id order
        [Key]
        [Column(Order = 1)]
        [Required]
        public int product_id { get; set; } //id product
        
        [Required]
        public int quantity { get; set; }
        [Required]
        public string price { get; set; }
        [ForeignKey("id_order")]
        public virtual Orders Orders { get; set; }
        [ForeignKey("product_id")]
        public virtual Products Products { get; set; }

    }
}