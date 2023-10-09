using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceProject.Models;
using InvoiceProject.DAL;

namespace InvoiceProject.BLL
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();

        public bool AuthenticateUser(string userName, string password)
        {
            User user = userRepository.UserAuthonticate(userName, password);
            if (user != null)
                return true;
            else
                return false;

        }
    }
}