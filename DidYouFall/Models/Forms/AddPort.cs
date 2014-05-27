using DidYouFall.Models.Utilities;
using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class AddPort
    {
        private AddPort()
        {            
        }

        public AddPort(User loggedUser, int serverId, int port)
        {
            try
            {
                var session = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
                Validations.Inputs vldInput = new Validations.Inputs();
                Validations.DataBase vldDb = new Validations.DataBase();
                vldInput.Port(port);
                vldDb.ServerOwner(loggedUser, serverId);
                var server = loggedUser.Servers.Where(i => i.Id == serverId).FirstOrDefault();
                if(!server.Ports.Contains(port))
                    server.Ports.Add(port);
                session.Save(server);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       
    }
}