using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MfinderContext;

namespace Model.DAOs
{
    public class MachineDAO
    {
        public static List<Machine> loadMachines()
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Machines
                        select it;
            List<Machine> list = query.ToList();
            return list;
        }
    }
}
