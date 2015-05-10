using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.JSONs
{
    public class MachineJSON : IJSONs
    {
        public string model { get; set; }
        public string name { get; set; }
        public string serialnumber { get; set; }
        public DateTime aquisitionDate { get; set; }
        public DateTime warrantyExpirationDate { get; set; }
        public int id { get; set; }

        public static List<MachineJSON> map(List<MfinderContext.Machine> machines)
        {
            List<MachineJSON> list = new List<MachineJSON>();
            foreach (MfinderContext.Machine machine in machines)
            {
                MachineJSON m = MachineJSON.map(machine);
                list.Add(m);
            }
            return list;
        }

        public static MachineJSON map(MfinderContext.Machine machine)
        {
            MachineJSON m = new MachineJSON();
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