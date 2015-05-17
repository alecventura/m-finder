using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model.DAOs;
using Model.JSONs.Request;
using Model;

namespace Presenter.Services
{
    class UserService
    {
        internal static user retrieveUserByUsername(string username)
        {
            return UserDAO.retrieveUserByUsername(username);
        }

        internal static bool registerNewUser(string username, string password, int role)
        {
            return UserDAO.registerNewUser(username, password, role);
        }

        internal static List<user> loadUsersData()
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

        internal static Pagination searchUsers(Model.JSONs.Request.UserRequest request)
        {
            return Model.DAOs.UserDAO.searchUsers(request);
        }
    }
}
