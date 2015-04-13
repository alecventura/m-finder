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
    }
}
