using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface ILogin : IBase
    {
        string username { get; }
        string password { get; }

        void openHomePage();

        void performSessionLogin();
    }
}
