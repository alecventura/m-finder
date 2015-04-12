using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class ManageUserPresenter : ValidatorPresenter
    {
        private InterfaceViews.IManageUser view;
        public ManageUserPresenter(InterfaceViews.IManageUser view)
        {
            this.view = view;
            loadUsersData();
        }

        private void loadUsersData()
        {
            List<MfinderContext.User> users = Services.UserService.loadUsersData();
            view.fillUsers(users);
        }
    }
}
