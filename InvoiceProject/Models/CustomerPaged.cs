using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceProject.Models
{
    public class CustomerPaged
    {
        public string sortBy { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int? RecordCount { get; set; } = 1;

        public string Search { get; set; }

        public List<Customer> CustomerList { get; set; }
    }
}