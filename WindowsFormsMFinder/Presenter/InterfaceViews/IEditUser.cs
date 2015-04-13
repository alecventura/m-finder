using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface IEditUser : IBase
    {
        string firstname { get; set; }
        string lastname { get; set; }
        string ramal { get; set; }
        int dpto { get; set; }
        int role { get; set; }
        int id { get; set; }
        void fillDptoList(List<MfinderContext.Dpto> list);
        void fillRoleList(List<MfinderContext.Role> list);

        void goToUsers();
    }
}
