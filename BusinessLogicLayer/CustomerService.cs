using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceEntities;
using DataAccessLayer;
using IBusinessLogicLayer;

namespace BusinessLogicLayer
{
    public class CustomerService : ICustomerService
    {
        CustomerRepository CustomerRepo = new CustomerRepository();

        public IEnumerable<Customer> CustomerList(CustomerPaged model)
        {
            List<Customer> CustomerList = CustomerRepo.ListCustomer(model);
            
            return (CustomerList);
        }
    }
}
