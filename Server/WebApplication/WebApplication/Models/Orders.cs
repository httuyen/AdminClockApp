using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Orders
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [MaxLength(100)]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [MaxLength(11)]
        public string phonenumber { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [MaxLength(100)]
        public string address { get; set; }
        [Required]
        [MaxLength(100)]
        public string datecreate { get; set; }
    }
}