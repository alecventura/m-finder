using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MfinderContext;

namespace Model
{
    public class UserService
    {

        public bool registerNewUser(string username, string password, int role)
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
                    user.RoleFk = role;
                }
                else
                {
                    user.RoleFk = (int)RoleEnum.Roles.USER; // User role
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
            return query.First();
        }
    }
}
