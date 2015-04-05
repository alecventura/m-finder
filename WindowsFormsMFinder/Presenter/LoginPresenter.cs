using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class LoginPresenter : ValidatorPresenter
    {
        InterfaceViews.ILogin view;
        public LoginPresenter(InterfaceViews.ILogin view)
        {
            this.view = view;
        }

        public void view_loginEvent(object sender, EventArgs e)
        {

        }
    }
}
