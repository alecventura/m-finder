using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.JSONs;
using Model.JSONs.Request;
using System.Web.Services;
using System.Web.Script.Services;
using Model;

namespace WebBootstrapKnockout
{
    public partial class Loans : System.Web.UI.Page, Presenter.InterfaceViews.ILoans
    {
        public List<Item> dptos;
        public List<Item> roles;
        Presenter.LoansPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter = new Presenter.LoansPresenter(this);
        }

        public void fillDptoList(List<dpto> list)
        {
            List<Item> jsons = new List<Item>();
            foreach (dpto i in list)
            {
                jsons.Add(new Item(i.id, i.name));
            }
            this.dptos = jsons;
        }

        public void fillRoleList(List<role> list)
        {
            List<Item> jsons = new List<Item>();
            foreach (role i in list)
            {
                jsons.Add(new Item(i.id, i.name));
            }
            this.roles = jsons;
        }

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
        }

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static Pagination searchMachines(MachineRequest machineRequest)
        //{
        //    return Presenter.MachinesPresenter.staticSearchMachines(machineRequest);
        //}

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static Pagination searchUsers(UserRequest userRequest)
        //{
        //    return Presenter.UsersPresenter.staticSearchUsers(userRequest);
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Pagination searchLoans(LoanRequest request)
        {
            return Presenter.LoansPresenter.staticSearchLoans(request);
        }

        [WebMethod]
        [GenerateScriptType(typeof(UserJSON))]
        [GenerateScriptType(typeof(MachineJSON))]
        [GenerateScriptType(typeof(Model.JSONs.NewLoan.AditionalJSON))]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<LoanJSON> saveNewLoan(NewLoan loan)
        {
            Presenter.LoansPresenter.staticSaveNewLoan(loan);

            List<Model.DAOs.LoanDAO.Loan> loans = Presenter.LoansPresenter.staticLoadLoans();
            return LoanJSON.map(loans);

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<LoanJSON> returnLoan(int id)
        {
            Presenter.LoansPresenter.returnLoan(id);

            List<Model.DAOs.LoanDAO.Loan> loans = Presenter.LoansPresenter.staticLoadLoans();
            return LoanJSON.map(loans);

        }


    }
}