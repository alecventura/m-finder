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

        public static List<MachineJSON> map(List<machine> machines)
        {
            List<MachineJSON> list = new List<MachineJSON>();
            foreach (machine machine in machines)
            {
                MachineJSON m = MachineJSON.map(machine);
                list.Add(m);
            }
            return list;
        }

        public static MachineJSON map(machine machine)
        {
            MachineJSON m = new MachineJSON();
            m.model = machine.model;
            m.name = machine.name;
            m.id = machine.id;
            m.serialnumber = machine.serialnumber;
            if (machine.warrantyExpirationDate != null)
            {
                m.warrantyExpirationDate = (DateTime)machine.warrantyExpirationDate;
            }
            if (machine.aquisitionDate != null)
            {
                m.aquisitionDate = (DateTime)machine.aquisitionDate;
            }
            return m;
        }
    }
}