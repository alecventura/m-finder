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

        internal static bool staticSaveNewLoan(Model.JSONs.NewLoan loan)
        {
            return LoanDAO.saveNewLoan(loan.machine.id, loan.user.id, loan.aditional.loanDate, loan.user.dpto);
        }

        internal static bool returnLoan(int id)
        {
            return LoanDAO.returnLoan(id);
        }
    }
}
