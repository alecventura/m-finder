using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MfinderContext;
using System.Diagnostics;
using Model.JSONs.Request;
using Model.JSONs;

namespace Model.DAOs
{
    public class LoanDAO
    {
        public class Loan
        {
            public User user { get; set; }
            public Machine machine { get; set; }
            public Dpto dpto { get; set; }
            public int id { get; set; }
        }
        public static List<Loan> loadLoans()
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from loan in context.Locations
                        join user in context.Users on loan.UserFk equals user.Id
                        join dpto in context.Dptos on loan.DptoFk equals dpto.Id
                        join machine in context.Machines on loan.MachineFk equals machine.Id
                        select new Loan { user = user, dpto = dpto, machine = machine, id = loan.Id };
            List<Loan> list = query.ToList();
            return list;
        }

        public static bool saveNewLoan(int machineId, int userId, DateTime loanDate, int dpto_fk)
        {
            try
            {
                MfinderDataContext context = new MfinderDataContext();
                Location loan = new Location();
                loan.MachineFk = machineId;
                loan.UserFk = userId;
                loan.LoanDate = loanDate;
                loan.DptoFk = dpto_fk;

                context.Locations.InsertOnSubmit(loan);
                context.SubmitChanges();
                saveHistory(loan);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        private static void saveHistory(Location loan)
        {
        }

        public static bool returnLoan(int id)
        {
            try
            {
                MfinderDataContext context = new MfinderDataContext();
                var loan = context.Locations.Where(item => item.Id == id).Single();
                context.Locations.DeleteOnSubmit(loan);
                context.SubmitChanges();
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

            MfinderDataContext context = new MfinderDataContext();
            var query = from loan in context.Locations
                        join user in context.Users on loan.UserFk equals user.Id
                        join dpto in context.Dptos on loan.DptoFk equals dpto.Id
                        join machine in context.Machines on loan.MachineFk equals machine.Id
                        select new Loan { user = user, dpto = dpto, machine = machine, id = loan.Id };

            p.total = query.Count();

            if (request.offset > 0)
            {
                query = query.Skip(request.offset);
                p.offset = request.offset;
            }
            if (request.limit > 0)
                query = query.Take(request.limit);
            var sql = query.ToString();

            List<Loan> list = query.ToList();
            List<LoanJSON> jsons = LoanJSON.map(list);

            p.list = jsons.Cast<IJSONs>().ToList();
            return p;
        }
    }
}
