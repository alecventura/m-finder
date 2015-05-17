using Model;
using Model.JSONs;
using Model.JSONs.Request;
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
        }

        public static bool deleteMachine(int id)
        {
            return Services.MachineService.deleteMachine(id);
        }

        public static List<machine> staticLoadMachinesData()
        {
            List<machine> machines = Services.MachineService.loadMachines();
            return machines;
        }

        public static bool saveMachine(MachineJSON machine)
        {
            bool success = Services.MachineService.saveMachine(machine.model, machine.serialnumber, machine.name, machine.aquisitionDate, machine.warrantyExpirationDate, machine.id);
            return success;
        }

        //public static List<MachineJSON> searchMachinesData(MachineRequest request)
        //{
        //    Pagination p = Services.MachineService.searchMachines(request);
        //    return p.list.Cast<MachineJSON>().ToList();
        //}

        public static Pagination staticSearchMachines(MachineRequest request)
        {
            return Services.MachineService.searchMachines(request);
        }
    }
}
