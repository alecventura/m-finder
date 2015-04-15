using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Services;
using Presenter.Utils;

namespace Presenter
{
    public class EditUserPresenter : ValidatorPresenter
    {
        private InterfaceViews.IEditUser view;
        public EditUserPresenter(InterfaceViews.IEditUser view)
        {
            this.view = view;
            view.fillDptoList(Services.DptoService.loadAll());
            view.fillRoleList(filterRoles(Services.RoleService.loadAll()));
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

        public void saveUser(object sender, EventArgs e)
        {
            if (!validateUser(view.firstname, view.lastname, view.ramal, view.dpto, view.role))
            {
                //Have to make a validation per field.
                view.showMessage("All fields are required!");
            }

            bool success = UserService.saveUser(view.firstname, view.lastname, view.ramal, view.dpto, view.role, view.id);

            if (success)
            {
                bool click = view.showMessage("User " + view.firstname + " " + view.lastname + " successfully saved!");
                if (click)
                {
                    view.goToUsers();
                }
            }
            else
            {
                view.showMessage("User " + view.firstname + " " + view.lastname + " cannot be created!");
            }
        }
    }
}
