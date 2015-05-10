using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.JSONs;
using System.Web.Services;
using System.Web.Script.Services;
using Model.JSONs.Request;

namespace WebBootstrapKnockout
{
    public partial class EditMachine : System.Web.UI.Page, Presenter.InterfaceViews.IMachines
    {
        Presenter.MachinesPresenter presenter;
        public List<Item> dptos;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Presenter.MachinesPresenter(this);
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

        public bool showMessage(string message)
        {
            throw new NotImplementedException();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<MachineJSON> removeMachine(MachineJSON machine)
        {
            bool delete = Presenter.MachinesPresenter.deleteMachine(machine.id);
            if (!delete)
            {
                HttpContext.Current.Response.Status = "500 Server Internal Error";
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.End();
                return null;
            }
            return MachineJSON.map(Presenter.MachinesPresenter.staticLoadMachinesData());
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<MachineJSON> saveMachine(MachineJSON machine)
        {
            if (!Presenter.MachinesPresenter.validateMachine(machine))
            {
                HttpContext.Current.Response.Status = "400 Bad Request";
                HttpContext.Current.Response.StatusCode = 400;
                HttpContext.Current.Response.End();
                return null;
            }
            bool save = Presenter.MachinesPresenter.saveMachine(machine);
            if (!save)
            {
                HttpContext.Current.Response.Status = "500 Server Internal Error";
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.End();
                return null;
            }
            return MachineJSON.map(Presenter.MachinesPresenter.staticLoadMachinesData());
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Pagination searchMachine(MachineRequest request)
        {

            Pagination pagination = Presenter.MachinesPresenter.searchMachine(request);
            return pagination;
        }
    }
}