using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model.DAOs;

namespace Presenter.Services
{
    class UserService
    {
        internal static MfinderContext.User retrieveUserByUsername(string username)
        {
            return UserDAO.retrieveUserByUsername(username);
        }

        internal static bool registerNewUser(string username, string password, int role)
        {
            return UserDAO.registerNewUser(username, password, role);
        }

        internal static List<MfinderContext.User> loadUsersData()
        {
            return UserDAO.loadUsersData();
        }

        internal static bool saveUser(string firstname, string lastname, string ramal, int dpto, int role, int id)
        {
            if (id > 0)
            {
                return UserDAO.updateUser(firstname, lastname, ramal, dpto, role, id);
            }
            else
            {
                return UserDAO.saveNewUser(firstname, lastname, ramal, dpto, role);
            }
        }

        internal static bool deleteUser(int id)
        {
            return UserDAO.deleteUser(id);
        }
    }
}
