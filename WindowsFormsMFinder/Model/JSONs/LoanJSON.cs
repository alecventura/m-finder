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
            l.machineSerialNumber = loan.machine.serialnumber;
            l.machineName = loan.machine.name;
            l.machineModel = loan.machine.model;
            if (loan.machine.aquisitionDate != null)
            {
                l.machineAquisitionDate = (DateTime)loan.machine.aquisitionDate;
            }
            if (loan.machine.warrantyExpirationDate != null)
            {
                l.machineWarrantyExpirationDate = (DateTime)loan.machine.warrantyExpirationDate;
            }
            if (loan.user.dpto.id != null)
            {
                l.userDpto = (int)loan.user.dpto.id;
            }
            l.userFirstname = loan.user.firstname;
            l.userLastName = loan.user.lastname;
            l.userRamal = loan.user.ramal;
            l.id = loan.id;
            return l;
        }
    }
}