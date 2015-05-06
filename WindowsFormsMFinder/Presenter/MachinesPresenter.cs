using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class MachinesPresenter : ValidatorPresenter
    {
        private InterfaceViews.IMachines view;

        public MachinesPresenter(InterfaceViews.IMachines view)
        {
            this.view = view;
            loadMachines();
        }

        public void loadMachines()
        {
            List<MfinderContext.Machine> machines = Services.MachineService.loadMachines();
            view.fillMachines(machines);
        }

        public static bool deleteMachine(int id)
        {
            return Services.MachineService.deleteMachine(id);
        }

        public static List<MfinderContext.Machine> staticLoadMachinesData()
        {
            List<MfinderContext.Machine> machines = Services.MachineService.loadMachines();
            return machines;
        }

        public static bool saveMachine(JSONs.Machine machine)
        {
            bool success = Services.MachineService.saveMachine(machine.model, machine.serialnumber, machine.name, machine.aquisitionDate, machine.warrantyExpirationDate, machine.id);
            return success;
        }

        public static List<MfinderContext.Machine> staticSearchMachinesData(JSONs.Request.MachineRequest machine)
        {
            List<MfinderContext.Machine> machines = Services.MachineService.searchMachines(machine);
            return machines;
        }
    }
}
