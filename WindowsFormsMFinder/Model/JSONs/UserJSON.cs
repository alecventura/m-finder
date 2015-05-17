using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.JSONs
{
    public class UserJSON : IJSONs
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string ramal { get; set; }
        public int dpto { get; set; }
        public int id { get; set; }
        public int role { get; set; }

        public static List<UserJSON> map(List<user> users)
        {
            List<UserJSON> usersJSON = new List<UserJSON>();
            foreach (user user in users)
            {
                if (!(String.IsNullOrEmpty(user.firstname) && String.IsNullOrEmpty(user.lastname) && String.IsNullOrEmpty(user.ramal)))
                {
                    UserJSON u = UserJSON.map(user);
                    usersJSON.Add(u);
                }
            }
            return usersJSON;
        }

        public static UserJSON map(user user)
        {
            UserJSON u = new UserJSON();
            u.firstname = user.firstname;
            u.lastname = user.lastname;
            u.ramal = user.ramal;
            if (user.dpto != null && user.dpto.id != null)
            {
                u.dpto = (int)user.dpto.id;
            }
            u.role = (int)user.role.id;
            u.role = (int)user.role.id;
            u.id = user.id;
            return u;
        }

    }
}