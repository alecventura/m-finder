using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Model.JSONs.Request;
using Model.JSONs;

namespace Model.DAOs
{
    public class LoanDAO
    {
        public class Loan
        {
            public user user { get; set; }
            public machine machine { get; set; }
            public dpto dpto { get; set; }
            public int id { get; set; }
        }
        public static List<Loan> loadLoans()
        {
            mfinderEntities context = new mfinderEntities();
            var query = from l in context.locations.Include("user").Include("dpto").Include("machine")
                        join u in context.users on l.user.id equals u.id
                        join d in context.dptoes on l.dpto.id equals d.id
                        join m in context.machines on l.machine.id equals m.id
                        select new Loan { user = u, dpto = d, machine = m, id = l.id };
            //context.
            List<Loan> list = query.ToList();
            return list;
        }

        public static bool saveNewLoan(int machineId, int userId, DateTime loanDate, int dpto_fk)
        {
            try
            {
                mfinderEntities context = new mfinderEntities();
                location loan = new location();
                loan.machine.id = machineId;
                loan.user.id = userId;
                loan.loanDate = loanDate;
                loan.dpto.id = dpto_fk;

                context.AddTolocations(loan);
                context.SaveChanges();
                saveHistory(loan);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        private static void saveHistory(location loan)
        {
        }

        public static bool returnLoan(int id)
        {
            try
            {
                mfinderEntities context = new mfinderEntities();
                var loan = context.locations.Include("user").Include("dpto").Include("machine").Where(item => item.id == id).Single();
                context.DeleteObject(loan);
                context.SaveChanges();
                saveHistory(loan);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static Pagination searchLoans(JSONs.Request.LoanRequest request)
        {
            Pagination p = new Pagination();

            mfinderEntities context = new mfinderEntities();
            var query = from loan in context.locations.Include("user").Include("dpto").Include("machine")
                        join user in context.users on loan.user.id equals user.id
                        join dpto in context.dptoes on loan.dpto.id equals dpto.id
                        join machine in context.machines on loan.machine.id equals machine.id
                        select new Loan { user = user, dpto = dpto, machine = machine, id = loan.id };

            p.total = query.Count();

            query = query.OrderBy(i => i.id);

            if (request.offset > 0)
            {
                query = query.Skip(request.offset);
                p.offset = request.offset;
            }
            if (request.limit > 0)
                query = query.Take(request.limit);

            List<Loan> list = query.ToList();
            List<LoanJSON> jsons = LoanJSON.map(list);

            p.list = jsons.Cast<IJSONs>().ToList();
            return p;
        }
    }
}
