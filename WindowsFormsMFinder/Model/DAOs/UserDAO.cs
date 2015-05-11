﻿using MfinderContext;
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
                MfinderDataContext context = new MfinderDataContext();
                User user = new User();
                user.Password = password;
                user.Username = username;
                if (role != null)
                {
                    //string stringValue = Enum.GetName(typeof(RoleEnum.Roles), role);
                    user.RoleFk = (int)role;
                }
                else
                {
                    user.RoleFk = 3; // User role
                }
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static User retrieveUserByUsername(string username)
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Users
                        where it.Username == username
                        select it;

            // Since we query for a single object instead of a collection, we can use the method First()
            User answer = query.FirstOrDefault();
            return answer;
        }

        public static List<User> loadUsersData()
        {
            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Users
                        select it;
            List<User> list = query.ToList();
            return list;
        }

        public static bool updateUser(string firstname, string lastname, string ramal, int dpto, int role, int id)
        {
            try
            {
                MfinderDataContext context = new MfinderDataContext();
                var query = from it in context.Users
                            where it.Id == id
                            select it;
                User user = query.FirstOrDefault();
                user.Firstname = firstname;
                user.Lastname = lastname;
                user.RoleFk = role;
                user.DptoFk = dpto;
                user.Ramal = ramal;

                context.SubmitChanges();
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
                MfinderDataContext context = new MfinderDataContext();
                User user = new User();
                user.Firstname = firstname;
                user.Lastname = lastname;
                user.RoleFk = role;
                user.DptoFk = dpto;
                user.Ramal = ramal;

                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
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
                MfinderDataContext context = new MfinderDataContext();
                var query = from it in context.Users
                            where it.Id == id
                            select it;
                User user = query.FirstOrDefault();
                context.Users.DeleteOnSubmit(user);
                context.SubmitChanges();
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

            MfinderDataContext context = new MfinderDataContext();
            var query = from it in context.Users
                        select it;

            if (!String.IsNullOrEmpty(request.firstname))
                query = query.Where(w => w.Firstname.ToLower().Contains(request.firstname.ToLower()));
            if (!String.IsNullOrEmpty(request.lastname))
                query = query.Where(w => w.Lastname.ToLower().Contains(request.lastname.ToLower()));
            if (!String.IsNullOrEmpty(request.ramal))
                query = query.Where(w => w.Ramal.ToLower().Contains(request.ramal.ToLower()));
            if (request.dpto > 0)
                query = query.Where(w => w.DptoFk == request.dpto);

            p.total = query.Count();

            if (request.offset > 0)
            {
                query = query.Skip(request.offset);
                p.offset = request.offset;
            }
            if (request.limit > 0)
                query = query.Take(request.limit);
            var sql = query.ToString();

            List<User> list = query.ToList();
            List<UserJSON> jsons = UserJSON.map(list);

            p.list = jsons.Cast<IJSONs>().ToList();
            return p;
        }

    }
}
