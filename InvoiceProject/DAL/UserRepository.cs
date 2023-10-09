using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using InvoiceProject.Models;

namespace InvoiceProject.DAL
{
    public class UserRepository
    {
        private string connString;

        public UserRepository()
        {
            connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        }
        public User UserAuthonticate(string UserName, string PassWord)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmnd = new SqlCommand("spGetUser", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.AddWithValue("@Name", UserName);
                cmnd.Parameters.AddWithValue("@PassWord", PassWord);
                conn.Open();
                SqlDataReader dr = cmnd.ExecuteReader();

                if (dr.Read())
                {
                    User user = new User()
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserName = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Password = dr["PassWord"].ToString(),
                        IsActive = Convert.ToBoolean(dr["IsActive"]),
                        CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        ModifiedDate = dr["ModifiedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ModifiedDate"]),
                        MoifiedBy = dr["ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["ModifiedBy"])
                    };
                    return user;
                }
                else
                    return null;

            }

        }
    }
}