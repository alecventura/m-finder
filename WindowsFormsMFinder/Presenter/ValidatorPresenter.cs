using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class ValidatorPresenter
    {
        protected bool validatePassword(string pw, string repeatPw)
        {
            return pw.Equals(repeatPw);
        }

        protected bool validateUsernamePassword(string username, string pw)
        {
            User user = Model.UserService.retrieveUserByUsername(username);
            return true; //TODO terminar
        }
    }
}
