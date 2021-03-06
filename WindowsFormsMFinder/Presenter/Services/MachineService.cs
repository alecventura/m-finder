﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace Presenter.Services
{
    public class MachineService
    {
        internal static List<machine> loadMachines()
        {
            return Model.DAOs.MachineDAO.loadMachines();
        }

        internal static bool saveMachine(string model, string serialnumber, string name, DateTime aquisitionDate, DateTime warrantyExpirationDate, int id)
        {
            if (id > 0)
            {
                return Model.DAOs.MachineDAO.updateMachine(model, serialnumber, name, aquisitionDate, warrantyExpirationDate, id);
            }
            else
            {
                return Model.DAOs.MachineDAO.saveMachine(model, serialnumber, name, aquisitionDate, warrantyExpirationDate);
            }

        }

        internal static bool deleteMachine(int id)
        {
            return Model.DAOs.MachineDAO.deleteMachine(id);
        }

        internal static Model.JSONs.Request.Pagination searchMachines(Model.JSONs.Request.MachineRequest machine)
        {
            return Model.DAOs.MachineDAO.searchMachines(machine);
        }
    }
}
