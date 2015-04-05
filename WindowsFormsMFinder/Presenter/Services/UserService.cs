using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Services
{
    class UserService
    {
        internal static MfinderContext.User retrieveUserByUsername(string username)
        {
            return Model.DAOs.UserDAO.retrieveUserByUsername(username);
        }

        internal static bool registerNewUser(string username, string password, int role)
        {
            return Model.DAOs.UserDAO.registerNewUser(username, password, role);
        }
    }
}
