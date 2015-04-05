using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IRegister
    {
        string username { get; }
        string password { get; }
        string repeatPw { get; }
        bool showMessage(string message);

        void goToLogin();
    }
}
