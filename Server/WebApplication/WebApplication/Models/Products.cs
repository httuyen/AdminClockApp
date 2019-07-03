using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }//id product
        public int id_category { get; set; }//id _categories

        [Required]
        [MaxLength(50)]
        public String title { get; set; }
        [Required]
        [MaxLength(200)]
        public String detail { get; set; }
        [Required]
        [MaxLength(15)]
        public string price { get; set; }
        
        [Required]
        public string image { get; set; }
        [ForeignKey("id_category")]
        public virtual Categories Categories { get; set; }
    }
}