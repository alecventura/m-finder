﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.JSONs
{
    public class NewLoan
    {
        public class AditionalJSON
        {
            public DateTime loanDate { get; set; }
        }

        public UserJSON user { get; set; }
        public MachineJSON machine { get; set; }
        public AditionalJSON aditional { get; set; }
    }
}
