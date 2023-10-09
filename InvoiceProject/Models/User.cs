﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InvoiceProject.Models
{
    public class User
    {
        public int UserId { get; set; }


        public string UserName { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? MoifiedBy { get; set; }
    }
}