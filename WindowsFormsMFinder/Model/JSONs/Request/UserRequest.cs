﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Model.JSONs.Request
{
    public class UserRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string ramal { get; set; }
        public int dpto { get; set; }
        [DefaultValue(10)]
        public int limit { get; set; }
        [DefaultValue(0)]
        public int offset { get; set; }
    }
}
