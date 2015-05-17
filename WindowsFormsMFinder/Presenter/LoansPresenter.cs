using Model;
using Model.JSONs;
using Model.JSONs.Request;
using Presenter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class LoansPresenter : ValidatorPresenter
    {
        private Presenter.InterfaceViews.ILoans view;

        public LoansPresenter(Presenter.InterfaceViews.ILoans view)
        {
            this.view = view;
            view.fillDptoList(Services.DptoService.loadAll());
            view.fillRoleList(filterRoles(Services.RoleService.loadAll()));
        }

        private List<role> filterRoles(List<role> list)
        {
            List<role> filtered = new List<role>();
            foreach (role role in list)
            {
                if (!(role.id.Equals((int)RoleEnum.Roles.ADMIN) || role.id.Equals((int)RoleEnum.Roles.TECH)))
                {
                    filtered.Add(role);
                }
            }
            return filtered;
        }

        public static List<Model.DAOs.LoanDAO.Loan> staticLoadLoans()
        {
            List<Model.DAOs.LoanDAO.Loan> loans = Services.LoansService.loadLoans();
            return loans;
        }

        public static bool staticSaveNewLoan(NewLoan loan)
        {
            bool success = Services.LoansService.staticSaveNewLoan(loan);
            return success;
        }

        public static bool returnLoan(int id)
        {
            bool success = Services.LoansService.returnLoan(id);
            return success;
        }

        public static Pagination staticSearchLoans(LoanRequest request)
        {
            Pagination loans = Services.LoansService.searchLoans(request);
            return loans;
        }
    }
}
