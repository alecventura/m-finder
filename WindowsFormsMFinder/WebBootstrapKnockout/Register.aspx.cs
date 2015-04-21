using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBootstrapKnockout
{
    public partial class Register : System.Web.UI.Page, Presenter.InterfaceViews.IRegister
    {
        Presenter.RegisterPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter = new Presenter.RegisterPresenter(this);
        }

        protected void onRegisterClicked(object sender, EventArgs e)
        {
            presenter.view_registerEvent(sender, e);
        }

        string Presenter.InterfaceViews.IRegister.username
        {
            get { return username.Text; }
        }

        string Presenter.InterfaceViews.IRegister.password
        {
            get { return password.Text; }
        }

        string Presenter.InterfaceViews.IRegister.repeatPw
        {
            get { return repeatPw.Text; }
        }

        public void goToLogin()
        {
            Response.Redirect("~/Login.aspx");
        }

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}