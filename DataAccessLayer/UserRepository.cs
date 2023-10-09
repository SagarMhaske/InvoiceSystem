using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceEntities;

namespace DataAccessLayer
{
    public class UserRepository
    {
        public User UserAuthonticate(UserLogin userLogin)
        {

            using (DataConection DB = new DataConection())
            {

                var user = DB.tblUsers.FirstOrDefault(u => u.Name == userLogin.UserName && u.PassWord == userLogin.Password);

                if (user != null)
                {

                    User user1 = new User();

                    user1.UserId = user.UserId;
                    user1.UserName = user.Name;
                    user1.Email = user.Email;
                    user1.Password = user.PassWord;
                    user1.IsActive = user.IsActive;
                    user1.CreatedDate = user.CreatedDate;
                    user1.CreatedBy = user.CreatedBy;
                    user1.ModifiedDate = user.ModifiedDate;
                    user1.MoifiedBy = user.ModifiedBy;

                    return user1;
                }
                else
                {
                    return null;
                }

            }

        }
    }
}
