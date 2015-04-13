using Presenter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Presenter.Utils;

namespace Presenter
{
    public class ValidatorPresenter
    {
        protected bool validatePassword(string pw, string repeatPw)
        {
            return pw.Equals(repeatPw);
        }

        protected bool validateUsernamePasswordAndRole(string username, string pw)
        {
            MfinderContext.User user = UserService.retrieveUserByUsername(username);
            if (user != null && (user.RoleFk.Equals((int)RoleEnum.Roles.ADMIN) || user.RoleFk.Equals((int)RoleEnum.Roles.TECH)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool validateUser(string firstname, string lastname, string ramal, int dpto, int role)
        {
            if (String.IsNullOrEmpty(firstname) || String.IsNullOrEmpty(lastname))
            {
                return false;
            }
            return true;
        }
    }
}
