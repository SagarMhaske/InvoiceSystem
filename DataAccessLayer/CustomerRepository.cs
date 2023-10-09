using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceEntities;

namespace DataAccessLayer
{
    public class CustomerRepository
    {
        public List<Customer> ListCustomer(CustomerPaged cp)
        {
            List<Customer> CustomerList = new List<Customer>();
            using ( DataConection DB = new DataConection())
            {
                var query = DB.sm_tblCustomer
                    .Where(c => string.IsNullOrEmpty(cp.Search) ||
                                (c.Name.Contains(cp.Search) || c.Email.Contains(cp.Search) || c.Address.Contains(cp.Search)))
                    .Where(c => c.IsActive == true)
                    .OrderBy(c => cp.sortDirection == "ASC" && cp.sortBy == "Email" ? c.Email :
                                 cp.sortDirection == "ASC" && cp.sortBy == "Address" ? c.Address :
                                 cp.sortDirection == "ASC" && cp.sortBy == "Name" ? c.Name : null)
                    .ThenByDescending(c => cp.sortDirection == "DESC" && cp.sortBy == "Email" ? c.Email :
                                           cp.sortDirection == "DESC" && cp.sortBy == "Address" ? c.Address :
                                           cp.sortDirection == "DESC" && cp.sortBy == "Name" ? c.Name : null)
                    .Select(c => new
                    {
                        c.CustomerId,
                        c.Name,
                        c.Email,
                        c.Address,
                        c.Contact,
                        c.IsActive,
                        c.CreatedDate,
                        c.CreatedBy,
                        c.ModifiedDate,
                        c.ModifiedBy
                    })
                    .Skip((cp.PageNumber - 1) * cp.PageSize)
                    .Take(cp.PageSize)
                    .ToList();

                int rowCount = DB.sm_tblCustomer
                    .Where(c => string.IsNullOrEmpty(cp.Search) ||
                                (c.Name.Contains(cp.Search) || c.Email.Contains(cp.Search) || c.Address.Contains(cp.Search) ))
                    .Where(c => c.IsActive == true)
                    .Count();

                foreach (var result in query)
                {
                    Customer customer = new Customer();
                    customer.CustomerId = result.CustomerId;
                    customer.Name = result.Name;
                    customer.Email = result.Email;
                    customer.Address = result.Address;
                    customer.Contact = Convert.ToInt64(result.Contact);
                    customer.IsActive = result.IsActive;
                    customer.CreatedDate = result.CreatedDate;
                    customer.CreatedBy = result.CreatedBy;
                    customer.ModifiedDate = result.ModifiedDate;
                    customer.ModifiedBy = result.ModifiedBy;
                    customer.rowCount = rowCount;

                    CustomerList.Add(customer);

                }
            }
            return CustomerList;
        }
    }
}
