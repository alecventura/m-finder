using Model.JSONs;
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
            loadLoans();
            view.fillDptoList(Services.DptoService.loadAll());
            view.fillRoleList(filterRoles(Services.RoleService.loadAll()));
        }

        private void loadLoans()
        {
            List<Model.DAOs.LoanDAO.Loan> loans = Services.LoansService.loadLoans();
            view.fillLoans(loans);
        }

        private List<MfinderContext.Role> filterRoles(List<MfinderContext.Role> list)
        {
            List<MfinderContext.Role> filtered = new List<MfinderContext.Role>();
            foreach (MfinderContext.Role role in list)
            {
                if (!(role.Id.Equals((int)RoleEnum.Roles.ADMIN) || role.Id.Equals((int)RoleEnum.Roles.TECH)))
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
    }
}
