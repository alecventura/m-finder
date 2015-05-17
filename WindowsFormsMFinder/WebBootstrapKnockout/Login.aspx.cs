using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBootstrapKnockout
{
    public partial class Login : System.Web.UI.Page, Presenter.InterfaceViews.ILogin
    {
        Presenter.LoginPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Presenter.LoginPresenter(this);

        }

        protected void onLoginClicked(object sender, EventArgs e)
        {
            presenter.view_loginEvent(sender, e);
        }
        protected void onGoToRegistrationClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }

        string Presenter.InterfaceViews.ILogin.username
        {
            get { return this.username.Text; }
        }

        string Presenter.InterfaceViews.ILogin.password
        {
            get { return this.password.Text; }
        }

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
        }


        public void openHomePage()
        {
            Response.Redirect("~/Loans.aspx");
        }


        public void performSessionLogin()
        {
            Context.Session["userLogged"] = true;
        }
    }
}