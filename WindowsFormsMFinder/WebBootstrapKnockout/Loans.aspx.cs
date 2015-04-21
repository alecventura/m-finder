using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presenter.JSONs;

namespace WebBootstrapKnockout
{
    public partial class Loans : System.Web.UI.Page, Presenter.InterfaceViews.ILoans
    {
        public List<Loan> loansJSON;
        Presenter.LoansPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter = new Presenter.LoansPresenter(this);
        }

        public void fillLoans(List<Model.DAOs.LoanDAO.Loan> loans)
        {
            loansJSON = Loan.map(loans);
        }

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}