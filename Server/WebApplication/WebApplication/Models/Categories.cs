using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Categories
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string title { get; set; }
    }
}