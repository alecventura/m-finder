using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.JSONs.Request
{
    public class Pagination
    {
        public List<IJSONs> list { get; set; }
        public int total { get; set; }
        public int offset { get; set; }
    }
}
