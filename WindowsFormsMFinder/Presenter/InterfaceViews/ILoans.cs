using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface ILoans : IBase
    {
        void fillDptoList(List<MfinderContext.Dpto> list);
        void fillRoleList(List<MfinderContext.Role> list);
    }
}
