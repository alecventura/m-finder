using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Services
{
    public class DptoService
    {
        internal static List<MfinderContext.Dpto> loadAll()
        {
            return Model.DAOs.DptoDAO.loadAll();
        }
    }
}
