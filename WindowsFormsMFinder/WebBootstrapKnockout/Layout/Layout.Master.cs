using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebBootstrapKnockout.Layout
{
    public partial class Layout : System.Web.UI.MasterPage, Presenter.InterfaceViews.IMaster
    {
        public bool userLogged = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //presenter = new Presenter.MasterPresenter(this);

            if (Context.Session == null || Context.Session.IsNewSession || (Context.Session["userLogged"] != null && !(bool)Context.Session["userLogged"]))
            {
                this.userLogged = false;
                if (!(Path.GetFileName(Request.Path).Equals("Login.aspx") || Path.GetFileName(Request.Path).Equals("Register.aspx")))
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            else if (Context.Session["userLogged"] != null && (bool)Context.Session["userLogged"])
            {
                this.userLogged = true;
            }
        }

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
        }

        protected void onLogoutClicked(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}