using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceProject.Models;
using InvoiceProject.DAL;


namespace InvoiceProject.BLL
{
    public class CustomerService
    {
        CustomerRepository CustomerRepository = new CustomerRepository();

        public List<Customer> CustomerList(int? PageNumber, int? PageSize, string sortBy = null, string Order = null ,string search = null)
        {
            List<Customer> CustomerList = CustomerRepository.ListCustomer( PageNumber,  PageSize  ,  sortBy ,  Order, search  );
            return (CustomerList);
        }


        public List<Customer> CustomerList(string sortBy = null, int? PageNumber = null, int? PageSize = null)
        {

            string SortBy = null;
            string Order = null;

            switch (sortBy)
            {
                case "Name desc":
                    SortBy = "Name";
                    Order = "DESC";
                    break;
                case "Name":
                    SortBy = "Name";
                    Order = "ASC";
                    break;
                case "Email desc":
                    SortBy = "Email";
                    Order = "DESC";
                    break;
                case "Email":
                    SortBy = "Name";
                    Order = "ASC";
                    break;
                case "Address desc":
                    SortBy = "Address";
                    Order = "DESC";
                    break;
                case "Address":
                    SortBy = "Address";
                    Order = "ASC";
                    break;

            }

            List<Customer> CustomerList = CustomerRepository.ListCustomer(PageNumber, PageSize, null, SortBy, Order);
            return (CustomerList);
        }

        public List<Customer> SearchCustomer( int? PageSize, string search = null)
        {

            List<Customer> CustomerList = CustomerRepository.ListCustomer(null, PageSize ,  search);
            return (CustomerList);
        }        
    }
}