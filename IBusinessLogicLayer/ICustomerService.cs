using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceEntities;

namespace IBusinessLogicLayer
{
    public interface ICustomerService
    {
         IEnumerable<Customer> CustomerList(CustomerPaged model);  
    }
}
