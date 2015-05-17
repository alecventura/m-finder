using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAOs
{
    public class DptoDAO
    {
        public static List<dpto> loadAll()
        {
            mfinderEntities context = new mfinderEntities();
            var query = from it in context.dptoes
                        select it;
            List<dpto> list = query.ToList();
            return list;
        }
    }
}
