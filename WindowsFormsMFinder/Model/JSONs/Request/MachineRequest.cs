using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Model.JSONs.Request
{
    public class MachineRequest
    {
        public string model { get; set; }
        public string name { get; set; }
        public string serialnumber { get; set; }
        [DefaultValue(0)]
        public int limit { get; set; }
        [DefaultValue(0)]
        public int offset { get; set; }
    }
}
