using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Utils;

namespace Presenter
{
    public class UsersPresenter : ValidatorPresenter
    {
        private InterfaceViews.IUsers view;
        public UsersPresenter(InterfaceViews.IUsers view)
        {
            this.view = view;
            loadUsersData();
            view.addCellClickEvent();
        }

        public void loadUsersData()
        {
            List<MfinderContext.User> users = Services.UserService.loadUsersData();
            view.fillUsers(users);
        }

        public bool deleteUser(int id)
        {
            return Services.UserService.deleteUser(id);
        }

        public bool canEditUser(int role)
        {
            if (((int)RoleEnum.Roles.ADMIN).Equals(role))
            {
                return false;
            }
            return true;
        }
    }
}
