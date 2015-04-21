using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presenter.JSONs
{
    public class Machine
    {
        string model { get; set; }
        string name { get; set; }
        string serialnumber { get; set; }
        DateTime aquisitionDate { get; set; }
        DateTime warrantyExpirationDate { get; set; }
    }
}