using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Services
{
    public class DptoService
    {
        internal static List<dpto> loadAll()
        {
            return Model.DAOs.DptoDAO.loadAll();
        }
    }
}
