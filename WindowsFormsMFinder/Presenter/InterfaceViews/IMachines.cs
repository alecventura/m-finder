using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IMachines : IBase
    {
        void fillMachines(List<MfinderContext.Machine> machines);

        void addCellClickEvent();
        void goToMachines();

        bool showMessage(string message);

        int id { get; set; }
    }
}
