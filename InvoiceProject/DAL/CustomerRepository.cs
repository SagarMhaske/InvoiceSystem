using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using InvoiceProject.Models;
using System.Configuration;

namespace InvoiceProject.DAL
{
    public class CustomerRepository
    {
        public string ConnString;
        public CustomerRepository()
        {
            ConnString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        }


        public List<Customer> ListCustomer(int? PageNumber, int? PageSize  , string sortBy = null, string Order = null, string search = null)
        {
            
            List<Customer> CustomerList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand command = new SqlCommand("spGetCustomer", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Search", search);
                command.Parameters.AddWithValue("@sortBy", sortBy);
                command.Parameters.AddWithValue("@Order", Order);
                command.Parameters.AddWithValue("@PageNumber", PageNumber);
                command.Parameters.AddWithValue("@PageSize", PageSize);


                conn.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Customer customer = new Customer()
                    {
                        CustomerId = Convert.ToInt32(dr["CustomerId"]),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Address = dr["Address"].ToString(),
                        Contact = Convert.ToInt32(dr["Contact"]),
                        IsActive = Convert.ToBoolean(dr["IsActive"]),
                        CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        ModifiedDate = dr["ModifiedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ModifiedDate"]),
                        ModifiedBy = dr["ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["ModifiedBy"]),
                        RowCount = Convert.ToInt32(dr["RowCount"]),

                    };
                    CustomerList.Add(customer);
                }
                dr.Close();

                 
                return CustomerList;
            }

        }
       
    }
}
