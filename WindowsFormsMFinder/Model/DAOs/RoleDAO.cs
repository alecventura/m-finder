using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MfinderContext;

namespace Model.DAOs
{
    public class RoleDAO
    {
        public static List<Role> loadAll()
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Roles
                        select it;
            List<Role> list = query.ToList();
            return list;
        }
    }
}
