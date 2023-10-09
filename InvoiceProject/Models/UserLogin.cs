using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InvoiceProject.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required.")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}