using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IMachines : IBase
    {
        void fillDptoList(List<MfinderContext.Dpto> list);

        bool showMessage(string message);
    }
}
