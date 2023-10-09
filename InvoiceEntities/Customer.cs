using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceEntities
{
    public class Customer
    {
        
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public long Contact { get; set; }

        public int? rowCount { get; set; }
        
        public bool? IsActive { get; set; }
        
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
