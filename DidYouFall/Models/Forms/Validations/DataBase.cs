﻿using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms.Validations
{
    public class DataBase
    {
        public void RegisteredEmail(string email)
        {


            var session = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            {
                User user = session.QueryOver<User>().Where(i => i.Email == email).SingleOrDefault();
                if (user != null)
                    throw new Exception("Usuario já registado");
            }
        }

        public void RegisteredHostOnUser(string host, User loggedUser)
        {


            var session = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            {
                Server server = session.QueryOver<Server>().Where(i => i.Host == host && i.User == loggedUser).SingleOrDefault();
                if (server != null)
                    throw new Exception("Host já registrado");
            }
        }
    }
}