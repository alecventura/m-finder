using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Utils;
using Presenter.Services;
using Model.JSONs.Request;
using Model;

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
        }

        public static List<user> staticLoadUsersData()
        {
            List<user> users = Services.UserService.loadUsersData();
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

        private List<role> filterRoles(List<role> list)
        {
            List<role> filtered = new List<role>();
            foreach (role role in list)
            {
                if (!(role.id.Equals((int)RoleEnum.Roles.ADMIN) || role.id.Equals((int)RoleEnum.Roles.TECH)))
                {
                    filtered.Add(role);
                }
            }
            return filtered;
        }

        public static bool saveUser(Model.JSONs.UserJSON user)
        {
            bool success = UserService.saveUser(user.firstname, user.lastname, user.ramal, user.dpto, user.role, user.id);
            return success;
        }

        public static Pagination staticSearchUsers(Model.JSONs.Request.UserRequest userRequest)
        {
            Pagination users = Services.UserService.searchUsers(userRequest);
            return users;
        }
    }
}
