using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IUsers : IBase
    {
        void fillUsers(List<MfinderContext.User> users);

        //JSONs.User userJSON;
        void fillDptoList(List<MfinderContext.Dpto> list);
        void fillRoleList(List<MfinderContext.Role> list);

        void goToUsers();
    }
}
