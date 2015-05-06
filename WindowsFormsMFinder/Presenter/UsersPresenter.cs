using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Utils;
using Presenter.Services;

namespace Presenter
{
    public class UsersPresenter : ValidatorPresenter
    {
        private InterfaceViews.IUsers view;
        public UsersPresenter(InterfaceViews.IUsers view)
        {
            this.view = view;
            view.fillDptoList(Services.DptoService.loadAll());
            view.fillRoleList(filterRoles(Services.RoleService.loadAll()));
            loadUsersData();
        }

        public void loadUsersData()
        {
            List<MfinderContext.User> users = Services.UserService.loadUsersData();
            view.fillUsers(users);
        }

        public static List<MfinderContext.User> staticLoadUsersData()
        {
            List<MfinderContext.User> users = Services.UserService.loadUsersData();
            return users;
        }

        public static bool deleteUser(int id)
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

        private List<MfinderContext.Role> filterRoles(List<MfinderContext.Role> list)
        {
            List<MfinderContext.Role> filtered = new List<MfinderContext.Role>();
            foreach (MfinderContext.Role role in list)
            {
                if (!(role.Id.Equals((int)RoleEnum.Roles.ADMIN) || role.Id.Equals((int)RoleEnum.Roles.TECH)))
                {
                    filtered.Add(role);
                }
            }
            return filtered;
        }

        public static bool saveUser(JSONs.User user)
        {
            bool success = UserService.saveUser(user.firstname, user.lastname, user.ramal, user.dpto, user.role, user.id);
            return success;
        }

        public static List<MfinderContext.User> staticSearchUsers(JSONs.Request.UserRequest userRequest)
        {
            List<MfinderContext.User> users = Services.UserService.searchUsers(userRequest);
            return users;
        }
    }
}
