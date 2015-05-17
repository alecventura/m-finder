using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.JSONs.Request;
using Model.JSONs;

namespace Model.DAOs
{
    public class MachineDAO
    {
        public static List<machine> loadMachines()
        {
            mfinderEntities context = new mfinderEntities();
            var query = from it in context.machines
                        select it;
            List<machine> list = query.ToList();
            return list;
        }

        public static bool saveMachine(string model, string serialnumber, string name, DateTime aquisitionDate, DateTime warrantyExpirationDate)
        {
            try
            {
                mfinderEntities context = new mfinderEntities();
                machine m = new machine();
                m.serialnumber = serialnumber;
                m.name = name;
                m.model = model;
                m.aquisitionDate = aquisitionDate;
                m.warrantyExpirationDate = warrantyExpirationDate;

                context.AddTomachines(m);
                context.SaveChanges();

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
                mfinderEntities context = new mfinderEntities();
                var query = from it in context.machines
                            where it.id == id
                            select it;
                machine m = query.FirstOrDefault();
                m.serialnumber = serialnumber;
                m.name = name;
                m.model = model;
                m.aquisitionDate = aquisitionDate;
                m.warrantyExpirationDate = warrantyExpirationDate;

                context.SaveChanges();

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
                mfinderEntities context = new mfinderEntities();
                var query = from it in context.machines
                            where it.id == id
                            select it;
                machine m = query.FirstOrDefault();
                context.DeleteObject(m);
                context.SaveChanges();
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

            mfinderEntities context = new mfinderEntities();
            var query = from it in context.machines
                        select it;

            if (!String.IsNullOrEmpty(request.model))
                query = query.Where(w => w.model.ToLower().Contains(request.model.ToLower()));
            if (!String.IsNullOrEmpty(request.name))
                query = query.Where(w => w.name.ToLower().Contains(request.name.ToLower()));
            if (!String.IsNullOrEmpty(request.serialnumber))
                query = query.Where(w => w.serialnumber.ToLower().Contains(request.serialnumber.ToLower()));

            p.total = query.Count();

            query = query.OrderBy(i => i.name);

            if (request.offset > 0)
            {
                query = query.Skip(request.offset);
                p.offset = request.offset;
            }
            if (request.limit > 0)
                query = query.Take(request.limit);
            var sql = query.ToString();

            List<machine> list = query.ToList();
            List<MachineJSON> jsons = MachineJSON.map(list);

            p.list = jsons.Cast<IJSONs>().ToList();
            return p;
        }
    }
}
