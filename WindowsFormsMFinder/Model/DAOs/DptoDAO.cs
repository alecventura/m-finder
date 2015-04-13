using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MfinderContext;

namespace Model.DAOs
{
    public class DptoDAO
    {
        public static List<Dpto> loadAll()
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Dptos
                        select it;
            List<Dpto> list = query.ToList();
            return list;
        }
    }
}
