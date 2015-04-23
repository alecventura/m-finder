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
        }

        private void loadLoans()
        {
            List<Model.DAOs.LoanDAO.Loan> loans = Services.LoansService.loadLoans();
            view.fillLoans(loans);
        }
    }
}
