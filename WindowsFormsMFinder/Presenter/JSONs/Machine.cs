using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presenter.JSONs
{
    public class Machine
    {
        public string model { get; set; }
        public string name { get; set; }
        public string serialnumber { get; set; }
        public DateTime aquisitionDate { get; set; }
        public DateTime warrantyExpirationDate { get; set; }
        public int id { get; set; }

        public static List<Machine> map(List<MfinderContext.Machine> machines)
        {
            List<Machine> list = new List<Machine>();
            foreach (MfinderContext.Machine machine in machines)
            {
                Machine m = Machine.map(machine);
                list.Add(m);
            }
            return list;
        }

        public static Machine map(MfinderContext.Machine machine)
        {
            Machine m = new Machine();
            m.model = machine.Model;
            m.name = machine.Name;
            m.id = machine.Id;
            m.serialnumber = machine.Serialnumber;
            if (machine.WarrantyExpirationDate != null)
            {
                m.warrantyExpirationDate = (DateTime)machine.WarrantyExpirationDate;
            }
            if (machine.AquisitionDate != null)
            {
                m.aquisitionDate = (DateTime)machine.AquisitionDate;
            }
            return m;
        }
    }
}