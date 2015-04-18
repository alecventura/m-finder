using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface ILoans : IBase
    {
        void fillLoans(List<Model.DAOs.LoanDAO.Loan> loans);
    }
}
