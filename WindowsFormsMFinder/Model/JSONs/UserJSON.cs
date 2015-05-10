using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.JSONs
{
    public class UserJSON
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string ramal { get; set; }
        public int dpto { get; set; }
        public int id { get; set; }
        public int role { get; set; }

        public static List<UserJSON> map(List<MfinderContext.User> users)
        {
            List<UserJSON> usersJSON = new List<UserJSON>();
            foreach (MfinderContext.User user in users)
            {
                if (!(String.IsNullOrEmpty(user.Firstname) && String.IsNullOrEmpty(user.Lastname) && String.IsNullOrEmpty(user.Ramal)))
                {
                    UserJSON u = UserJSON.map(user);
                    usersJSON.Add(u);
                }
            }
            return usersJSON;
        }

        public static UserJSON map(MfinderContext.User user)
        {
            UserJSON u = new UserJSON();
            u.firstname = user.Firstname;
            u.lastname = user.Lastname;
            u.ramal = user.Ramal;
            if (user.DptoFk != null)
            {
                u.dpto = (int)user.DptoFk;
            }
            u.role = (int)user.RoleFk;
            u.id = user.Id;
            return u;
        }

    }
}