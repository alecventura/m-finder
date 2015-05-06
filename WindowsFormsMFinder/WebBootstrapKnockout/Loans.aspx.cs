using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presenter.JSONs;
using Presenter.JSONs.Request;
using System.Web.Services;
using System.Web.Script.Services;

namespace WebBootstrapKnockout
{
    public partial class Loans : System.Web.UI.Page, Presenter.InterfaceViews.ILoans
    {
        public List<Loan> loansJSON;
        public List<Item> dptos;
        public List<Item> roles;
        Presenter.LoansPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter = new Presenter.LoansPresenter(this);
        }

        public void fillDptoList(List<MfinderContext.Dpto> list)
        {
            List<Item> jsons = new List<Item>();
            foreach (MfinderContext.Dpto i in list)
            {
                jsons.Add(new Item(i.Id, i.Name));
            }
            this.dptos = jsons;
        }

        public void fillRoleList(List<MfinderContext.Role> list)
        {
            List<Item> jsons = new List<Item>();
            foreach (MfinderContext.Role i in list)
            {
                jsons.Add(new Item(i.Id, i.Name));
            }
            this.roles = jsons;
        }

        public void fillLoans(List<Model.DAOs.LoanDAO.Loan> loans)
        {
            loansJSON = Loan.map(loans);
        }

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<Presenter.JSONs.Machine> searchMachines(MachineRequest machineRequest)
        {
            return Presenter.JSONs.Machine.map(Presenter.MachinesPresenter.staticSearchMachinesData(machineRequest));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<Presenter.JSONs.User> searchUsers(UserRequest userRequest)
        {
            return Presenter.JSONs.User.map(Presenter.UsersPresenter.staticSearchUsers(userRequest));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<Presenter.JSONs.Loan> saveNewLoan(NewLoan loan)
        {
            Presenter.LoansPresenter.staticSaveNewLoan(loan);

            List<Model.DAOs.LoanDAO.Loan> loans = Presenter.LoansPresenter.staticLoadLoans();
            return Loan.map(loans);

        }

    }
}