using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IManageUser : IBase
    {
        void fillUsers(List<MfinderContext.User> users);
    }
}
