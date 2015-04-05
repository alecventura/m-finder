using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IRegister : IBase
    {
        string username { get; }
        string password { get; }
        string repeatPw { get; }

        void goToLogin();
    }
}
