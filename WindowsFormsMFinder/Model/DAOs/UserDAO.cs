using MfinderContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAOs
{
    public class UserDAO
    {
        public static bool registerNewUser(string username, string password, Object role)
        {
            try
            {
                MfinderDataContext context = new MfinderDataContext();
                User user = new User();
                user.Password = password;
                user.Username = username;
                if (role != null)
                {
                    //string stringValue = Enum.GetName(typeof(RoleEnum.Roles), role);
                    user.RoleFk = (int)role;
                }
                else
                {
                    user.RoleFk = 3; // User role
                }
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static User retrieveUserByUsername(string username)
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Users
                        where it.Username == username
                        select it;

            // Since we query for a single object instead of a collection, we can use the method First()
            User answer = query.FirstOrDefault();
            return answer;
        }
    }
}
