using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presenter.JSONs
{
    public class Loan
    {
        public string machineName { get; set; }
        public string machineModel { get; set; }
        public string machineSerialNumber { get; set; }


        public static List<Loan> map(List<Model.DAOs.LoanDAO.Loan> loans)
        {
            List<Loan> list = new List<Loan>();

            foreach (Model.DAOs.LoanDAO.Loan loan in loans)
            {
                Loan l = Loan.map(loan);
                list.Add(l);
            }

            return list;
        }

        public static Loan map(Model.DAOs.LoanDAO.Loan loan)
        {
            Loan l = new Loan();
            l.machineSerialNumber = loan.machine.Serialnumber;
            l.machineName = loan.machine.Name;
            l.machineModel = loan.machine.Model;
            return l;
        }
    }
}