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
    }
}
