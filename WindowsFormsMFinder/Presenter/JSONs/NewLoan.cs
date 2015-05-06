using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.JSONs
{
    public class NewLoan
    {
        public User user { get; set; }
        public Machine machine { get; set; }
        public DateTime loanDate { get; set; }
    }
}
