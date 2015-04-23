using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Presenter.InterfaceViews;
using Presenter.JSONs;
using System.Web.Script.Services;

namespace WebBootstrapKnockout
{
    public partial class Users : System.Web.UI.Page, Presenter.InterfaceViews.IUsers
    {
        Presenter.UsersPresenter presenter;
        public List<User> usersJSON;
        public List<Item> dptos;
        public List<Item> roles;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Presenter.UsersPresenter(this);
        }

        public void fillUsers(List<MfinderContext.User> users)
        {
            this.usersJSON = Presenter.JSONs.User.map(users);
        }

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<Presenter.JSONs.User> removeUser(User user)
        {
            bool delete = Presenter.UsersPresenter.deleteUser(user.id);
            if (!delete)
            {
                HttpContext.Current.Response.Status = "500 Server Internal Error";
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.End();
                return null;
            }
            return Presenter.JSONs.User.map(Presenter.UsersPresenter.staticLoadUsersData());
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<Presenter.JSONs.User> saveUser(User user)
        {
            if (!Presenter.UsersPresenter.validateUser(user))
            {
                HttpContext.Current.Response.Status = "400 Bad Request";
                HttpContext.Current.Response.StatusCode = 400;
                HttpContext.Current.Response.End();
                return null;
            }
            bool save = Presenter.UsersPresenter.saveUser(user);
            if (!save)
            {
                HttpContext.Current.Response.Status = "500 Server Internal Error";
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.End();
                return null;
            }
            return Presenter.JSONs.User.map(Presenter.UsersPresenter.staticLoadUsersData());
        }
    }
}