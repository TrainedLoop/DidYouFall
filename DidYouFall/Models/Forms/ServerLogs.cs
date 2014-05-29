using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DidYouFall.Repository;

namespace DidYouFall.Models.Forms
{
    public class ServerLogs
    {
        public List<Server> Servers { get; private set; }
        public List<ServerLog> Logs { get; set; }

        public ServerLogs(User LoggedUser)
        {
            Servers = LoggedUser.Servers.ToList();
            Logs = new List<ServerLog>();
        }

        public void SelectServer(int Id)
        {
            Logs = Servers.Where(i => i.Id == Id).FirstOrDefault().Logs.ToList();
        }
    }
}