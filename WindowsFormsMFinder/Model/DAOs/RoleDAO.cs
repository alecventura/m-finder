using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAOs
{
    public class RoleDAO
    {
        public static List<role> loadAll()
        {
            mfinderEntities context = new mfinderEntities();
            var query = from it in context.roles
                        select it;
            List<role> list = query.ToList();
            return list;
        }
    }
}
