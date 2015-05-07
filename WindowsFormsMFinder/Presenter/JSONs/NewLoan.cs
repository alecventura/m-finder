using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.JSONs
{
    public class NewLoan
    {
        public class Aditional
        {
            public DateTime loanDate { get; set; }
        }

        public User user { get; set; }
        public Machine machine { get; set; }
        public Aditional aditional { get; set; }
    }
}
