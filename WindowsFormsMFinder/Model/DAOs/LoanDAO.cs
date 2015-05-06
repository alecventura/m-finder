using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MfinderContext;
using System.Diagnostics;

namespace Model.DAOs
{
    public class LoanDAO
    {
        public class Loan
        {
            public User user { get; set; }
            public Machine machine { get; set; }
            public Dpto dpto { get; set; }
        }
        public static List<Loan> loadLoans()
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from loan in context.Locations
                        join user in context.Users on loan.UserFk equals user.Id
                        join dpto in context.Dptos on loan.DptoFk equals dpto.Id
                        join machine in context.Machines on loan.MachineFk equals machine.Id
                        select new Loan { user = user, dpto = dpto, machine = machine };
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
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
