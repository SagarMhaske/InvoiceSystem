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
    public class UserService : IUserService
    {
        UserRepository userRepository = new UserRepository();

        public bool AuthenticateUser(UserLogin userLogin)
        {
            User user = userRepository.UserAuthonticate(userLogin);
            if (user != null)
                return true;
            else
                return false;

        }
    }
}
