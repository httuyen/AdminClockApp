using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Username is Required")]
        [MaxLength(20)]
        [MinLength(6)]
        public string username { get; set; }
        [MaxLength(30)]
        [MinLength(8)]
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(20)]
        public string name { get; set; }
        
        public string email { get; set; }
        
        public int phonenumber { get; set; }
        
        public string address { get; set; }
        [DefaultValue(true)]
        public bool isAdmin { get; set; }
    }
}