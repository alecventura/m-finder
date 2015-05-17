using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Services
{
    public class RoleService
    {
        internal static List<role> loadAll()
        {
            return Model.DAOs.RoleDAO.loadAll();
        }
    }
}
