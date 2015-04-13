using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IEditMachines
    {
        string model { get; set; }
        string name { get; set; }
        string serialnumber { get; set; }
        DateTime aquisitionDate { get; set; }
        DateTime warrantyExpirationDate { get; set; }
        void goToMachines();
    }
}
