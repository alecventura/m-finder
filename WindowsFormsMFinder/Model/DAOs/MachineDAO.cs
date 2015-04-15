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

        public static bool saveMachine(string model, string serialnumber, string name, DateTime aquisitionDate, DateTime warrantyExpirationDate)
        {
            try
            {
                MfinderDataContext context = new MfinderDataContext();
                Machine m = new Machine();
                m.Serialnumber = serialnumber;
                m.Name = name;
                m.Model = model;
                m.AquisitionDate = aquisitionDate;
                m.WarrantyExpirationDate = warrantyExpirationDate;

                context.Machines.InsertOnSubmit(m);
                context.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool updateMachine(string model, string serialnumber, string name, DateTime aquisitionDate, DateTime warrantyExpirationDate, int id)
        {
            try
            {
                MfinderDataContext context = new MfinderDataContext();
                var query = from it in context.Machines
                            where it.Id == id
                            select it;
                Machine m = query.FirstOrDefault();
                m.Serialnumber = serialnumber;
                m.Name = name;
                m.Model = model;
                m.AquisitionDate = aquisitionDate;
                m.WarrantyExpirationDate = warrantyExpirationDate;

                context.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool deleteMachine(int id)
        {
            try
            {
                MfinderDataContext context = new MfinderDataContext();
                var query = from it in context.Machines
                            where it.Id == id
                            select it;
                Machine m = query.FirstOrDefault();
                context.Machines.DeleteOnSubmit(m);
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
