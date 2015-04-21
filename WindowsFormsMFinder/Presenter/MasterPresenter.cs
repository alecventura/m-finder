using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter
{
    public class MasterPresenter
    {
        Presenter.InterfaceViews.IMaster view;
        public MasterPresenter(Presenter.InterfaceViews.IMaster view)
        {
            this.view = view;
        }
    }
}
