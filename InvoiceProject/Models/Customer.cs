using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InvoiceProject.Models
{
    public class Customer
    {
        //[DisplayName("Customer Id")]
        public int CustomerId { get; set; }


        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public long Contact { get; set; }

        //[DisplayName("Is Active")]
        public bool IsActive { get; set; }

        //[DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        //[DisplayName("Created By")]
        public int CreatedBy { get; set; }

        //[DisplayName("Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        //[DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        public int? RowCount { get; set; }


    }

}