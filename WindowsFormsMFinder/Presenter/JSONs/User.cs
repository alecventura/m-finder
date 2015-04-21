using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presenter.JSONs
{
    public class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string ramal { get; set; }
        public int dpto { get; set; }
        public int id { get; set; }
        public int role { get; set; }

        public static List<User> map(List<MfinderContext.User> users)
        {
            List<User> usersJSON = new List<User>();
            foreach (MfinderContext.User user in users)
            {
                if (!(String.IsNullOrEmpty(user.Firstname) && String.IsNullOrEmpty(user.Lastname) && String.IsNullOrEmpty(user.Ramal)))
                {
                    User u = User.map(user);
                    usersJSON.Add(u);
                }
            }
            return usersJSON;
        }

        public static User map(MfinderContext.User user)
        {
            User u = new User();
            u.firstname = user.Firstname;
            u.lastname = user.Lastname;
            u.ramal = user.Ramal;
            if (user.DptoFk != null)
            {
                u.dpto = (int)user.DptoFk;
            }
            if (user.RoleFk != null)
            {
                u.role = (int)user.RoleFk;
            }
            u.id = user.Id;
            return u;
        }

    }
}