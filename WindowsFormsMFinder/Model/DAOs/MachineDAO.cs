using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MfinderContext;
using Model.JSONs.Request;
using Model.JSONs;

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

        public static Pagination searchMachines(Model.JSONs.Request.MachineRequest request)
        {
            Pagination p = new Pagination();

            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Machines
                        select it;

            if (!String.IsNullOrEmpty(request.model))
                query = query.Where(w => w.Model.ToLower().Contains(request.model.ToLower()));
            if (!String.IsNullOrEmpty(request.name))
                query = query.Where(w => w.Name.ToLower().Contains(request.name.ToLower()));
            if (!String.IsNullOrEmpty(request.serialnumber))
                query = query.Where(w => w.Serialnumber.ToLower().Contains(request.serialnumber.ToLower()));

            p.total = query.Count();

            if (request.offset > 0)
            {
                query = query.Skip(request.offset);
                p.offset = request.offset;
            }
            if (request.limit > 0)
                query = query.Take(request.limit);
            var sql = query.ToString();

            List<Machine> list = query.ToList();
            List<MachineJSON> jsons = MachineJSON.map(list);

            p.list = jsons.Cast<IJSONs>().ToList();
            return p;
        }
    }
}
