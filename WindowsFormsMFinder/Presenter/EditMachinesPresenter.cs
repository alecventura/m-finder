using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Presenter.Services;

namespace Presenter
{
    public class EditMachinesPresenter : ValidatorPresenter
    {
        private InterfaceViews.IEditMachines view;
        public EditMachinesPresenter(InterfaceViews.IEditMachines view)
        {
            this.view = view;
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (!validateMachine(view.model, view.serialnumber, view.name, view.aquisitionDate, view.warrantyExpirationDate))
            {
                //Have to make a validation per field.
                view.showMessage("TODO: Machine validation!");
            }

            bool success = MachineService.saveMachine(view.model, view.serialnumber, view.name, view.aquisitionDate, view.warrantyExpirationDate, view.id);

            if (success)
            {
                bool click = view.showMessage("Machine " + view.name + " with serialnumber " + view.serialnumber + " successfully saved!");
                if (click)
                {
                    view.goToMachines();
                }
            }
            else
            {
                view.showMessage("Machine " + view.name + " with serialnumber " + view.serialnumber + " cannot be created!");
            }
        }

    }
}
