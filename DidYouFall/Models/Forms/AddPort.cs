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
        private User LoggedUser { get; set; }
        public List<Server> Servers { get; set; }
        public string Erro { get; set; }

        public AddPort(User loggedUser)
        {
            LoggedUser = loggedUser;
            Servers = ServerUtilities.GetAllServers(loggedUser) ?? new List<Server>();
        }

        public void Setup(Server server, int port)
        {
            var selectedServer = Servers.Where(i => i == server).SingleOrDefault();
            selectedServer.Ports.Add(port);
        }
    }
}