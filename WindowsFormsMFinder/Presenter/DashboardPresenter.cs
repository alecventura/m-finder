using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Presenter
{
    public class DashboardPresenter
    {
        private InterfaceViews.IDashboard view;
        public DashboardPresenter(InterfaceViews.IDashboard view)
        {
            this.view = view;
        }
    }
}
