using Model.JSONs;
using Model.JSONs.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Model.DAOs
{
    public class UserDAO
    {
        public static bool registerNewUser(string username, string password, Object role)
        {
            try
            {
                mfinderEntities context = new mfinderEntities();
                user user = new user();
                user.password = password;
                user.username = username;
                if (role != null)
                {
                    //string stringValue = Enum.GetName(typeof(RoleEnum.Roles), role);
                    user.role.id = (int)role;
                }
                else
                {
                    user.role.id = 3; // user role
                }
                context.AddTousers(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static user retrieveUserByUsername(string username)
        {
            mfinderEntities context = new mfinderEntities();
            var query = from it in context.users.Include("role").Include("dpto")
                        where it.username == username
                        select it;

            // Since we query for a single object instead of a collection, we can use the method First()
            user answer = query.FirstOrDefault();
            return answer;
        }

        public static List<user> loadUsersData()
        {
            mfinderEntities context = new mfinderEntities();
            var query = from it in context.users.Include("role").Include("dpto")
                        select it;
            List<user> list = query.ToList();
            return list;
        }

        public static bool updateUser(string firstname, string lastname, string ramal, int dpto, int role, int id)
        {
            try
            {
                mfinderEntities context = new mfinderEntities();
                var query = from it in context.users.Include("role").Include("dpto")
                            where it.id == id
                            select it;
                user user = query.FirstOrDefault();
                user.firstname = firstname;
                user.lastname = lastname;
                user.role.id = role;
                user.dpto.id = dpto;
                user.ramal = ramal;

                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static bool saveNewUser(string firstname, string lastname, string ramal, int dpto, int role)
        {
            try
            {
                mfinderEntities context = new mfinderEntities();
                user user = new user();
                user.firstname = firstname;
                user.lastname = lastname;
                user.role.id = role;
                user.dpto.id = dpto;
                user.ramal = ramal;

                context.AddTousers(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static bool deleteUser(int id)
        {
            try
            {
                mfinderEntities context = new mfinderEntities();
                var query = from it in context.users.Include("role").Include("dpto")
                            where it.id == id
                            select it;
                user user = query.FirstOrDefault();
                context.DeleteObject(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static Pagination searchUsers(Model.JSONs.Request.UserRequest request)
        {
            Pagination p = new Pagination();

            mfinderEntities context = new mfinderEntities();
            var query = from it in context.users.Include("role").Include("dpto")
                        select it;

            if (!String.IsNullOrEmpty(request.firstname))
                query = query.Where(w => w.firstname.ToLower().Contains(request.firstname.ToLower()));
            if (!String.IsNullOrEmpty(request.lastname))
                query = query.Where(w => w.lastname.ToLower().Contains(request.lastname.ToLower()));
            if (!String.IsNullOrEmpty(request.ramal))
                query = query.Where(w => w.ramal.ToLower().Contains(request.ramal.ToLower()));
            if (request.dpto > 0)
                query = query.Where(w => w.dpto.id == request.dpto);

            p.total = query.Count();

            query = query.OrderBy(i => i.firstname);

            if (request.offset > 0)
            {
                query = query.Skip(request.offset);
                p.offset = request.offset;
            }
            if (request.limit > 0)
                query = query.Take(request.limit);
            var sql = query.ToString();

            List<user> list = query.ToList();
            List<UserJSON> jsons = UserJSON.map(list);

            p.list = jsons.Cast<IJSONs>().ToList();
            return p;
        }

    }
}
