using Presenter.Services;
using Presenter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class RegisterPresenter : ValidatorPresenter
    {
        private InterfaceViews.IRegister view;

        public RegisterPresenter(InterfaceViews.IRegister view)
        {
            this.view = view;
        }

        public void view_registerEvent(object sender, EventArgs e)
        {
            if (!validatePassword(view.password, view.repeatPw))
            {
                view.showMessage("Passwords doesn't match!");
            }

            bool success = UserService.registerNewUser(view.username, view.password, (int)RoleEnum.Roles.TECH);

            if (success)
            {
                view.showMessage("User " + view.username + " successfully created!");
            }
            else
            {
                view.showMessage("User " + view.username + " cannot be created!");
            }
            view.goToLogin();
        }
    }
}
