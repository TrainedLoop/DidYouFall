using DidYouFall.Repository;
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

        public void RegisteredIPOnUser(string IP, User loggedUser)
        {


            var session = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            {
                Server server = session.QueryOver<Server>().Where(i => i.IP == IP && i.User == loggedUser).SingleOrDefault();
                if (server != null)
                    throw new Exception("IP já registrado");
            }
        }
        public  void ServerOwner(User loggedUser, int serverId)
        {
            var server = loggedUser.Servers.Where(i => i.Id == serverId).FirstOrDefault();
            if (server == null)
                throw new Exception("IP não cadastrado");
        }
    }
}