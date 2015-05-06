using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.DAOs;

namespace Presenter.Services
{
    public class LoansService
    {
        internal static List<LoanDAO.Loan> loadLoans()
        {
            return LoanDAO.loadLoans();
        }

        internal static bool staticSaveNewLoan(JSONs.NewLoan loan)
        {
            return LoanDAO.saveNewLoan(loan.machine.id, loan.user.id, loan.loanDate, loan.user.dpto);
        }
    }
}
