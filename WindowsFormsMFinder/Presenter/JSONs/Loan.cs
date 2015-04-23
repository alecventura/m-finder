using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presenter.JSONs
{
    public class Loan
    {
        //Machine Data
        public string machineName { get; set; }
        public string machineModel { get; set; }
        public string machineSerialNumber { get; set; }
        public DateTime machineAquisitionDate { get; set; }
        public DateTime machineWarrantyExpirationDate { get; set; }

        //User Data
        public string userFirstname { get; set; }
        public string userLastName { get; set; }
        public string userRamal { get; set; }
        public int userDpto { get; set; }

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
            if (loan.machine.AquisitionDate != null)
            {
                l.machineAquisitionDate = (DateTime)loan.machine.AquisitionDate;
            }
            if (loan.machine.WarrantyExpirationDate != null)
            {
                l.machineWarrantyExpirationDate = (DateTime)loan.machine.WarrantyExpirationDate;
            }
            if (loan.user.DptoFk != null)
            {
                l.userDpto = (int)loan.user.DptoFk;
            }
            l.userFirstname = loan.user.Firstname;
            l.userLastName = loan.user.Lastname;
            l.userRamal = loan.user.Ramal;
            return l;
        }
    }
}