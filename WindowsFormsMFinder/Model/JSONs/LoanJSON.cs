using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.JSONs
{
    public class LoanJSON : IJSONs
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

        //Loan Data
        public int id { get; set; }

        public static List<LoanJSON> map(List<Model.DAOs.LoanDAO.Loan> loans)
        {
            List<LoanJSON> list = new List<LoanJSON>();

            foreach (Model.DAOs.LoanDAO.Loan loan in loans)
            {
                LoanJSON l = LoanJSON.map(loan);
                list.Add(l);
            }

            return list;
        }

        public static LoanJSON map(Model.DAOs.LoanDAO.Loan loan)
        {
            LoanJSON l = new LoanJSON();
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
            l.id = loan.id;
            return l;
        }
    }
}