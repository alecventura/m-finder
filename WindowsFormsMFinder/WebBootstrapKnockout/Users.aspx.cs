using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Presenter.InterfaceViews;
using Model.JSONs;
using System.Web.Script.Services;
using Model.JSONs.Request;

namespace WebBootstrapKnockout
{
    public partial class Users : System.Web.UI.Page, Presenter.InterfaceViews.IUsers
    {
        Presenter.UsersPresenter presenter;
        public List<Item> dptos;
        public List<Item> roles;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Presenter.UsersPresenter(this);
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
        public static List<UserJSON> removeUser(UserJSON user)
        {
            bool delete = Presenter.UsersPresenter.deleteUser(user.id);
            if (!delete)
            {
                HttpContext.Current.Response.Status = "500 Server Internal Error";
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.End();
                return null;
            }
            return UserJSON.map(Presenter.UsersPresenter.staticLoadUsersData());
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<UserJSON> saveUser(UserJSON user)
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
            return UserJSON.map(Presenter.UsersPresenter.staticLoadUsersData());
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Pagination searchUsers(UserRequest request)
        {
            Pagination pagination = Presenter.UsersPresenter.staticSearchUsers(request);
            return pagination;
        }
    }
}