using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class MachinesPresenter
    {
        private InterfaceViews.IMachines view;

        public MachinesPresenter(InterfaceViews.IMachines view)
        {
            this.view = view;
            loadMachines();
            view.addCellClickEvent();
        }

        public void loadMachines()
        {
            List<MfinderContext.Machine> machines = Services.MachineService.loadMachines();
            view.fillMachines(machines);
        }

        public bool deleteMachine(int id)
        {
            return Services.MachineService.deleteMachine(id);
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            //if (!validateMachine(view.model, view.serialnumber, view.name, view.aquisitionDate, view.warrantyExpirationDate))
            //{
            //    //Have to make a validation per field.
            //    view.showMessage("TODO: Machine validation!");
            //}

            //bool success = MachineService.saveMachine(view.model, view.serialnumber, view.name, view.aquisitionDate, view.warrantyExpirationDate, view.id);

            //if (success)
            //{
            //    bool click = view.showMessage("Machine " + view.name + " with serialnumber " + view.serialnumber + " successfully saved!");
            //    if (click)
            //    {
            //        view.goToMachines();
            //    }
            //}
            //else
            //{
            //    view.showMessage("Machine " + view.name + " with serialnumber " + view.serialnumber + " cannot be created!");
            //}
        }
    }
}
