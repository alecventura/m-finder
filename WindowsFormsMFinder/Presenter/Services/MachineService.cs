using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace Presenter.Services
{
    public class MachineService
    {
        internal static List<MfinderContext.Machine> loadMachines()
        {
            return Model.DAOs.MachineDAO.loadMachines();
        }
    }
}
