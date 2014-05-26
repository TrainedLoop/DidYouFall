using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;

namespace DidYouFall.Models.Utilities
{
    public class ServerUtilities
    {
        public static List<Server> GetAllServers(User LoggedUser)
        {
            var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            var servers = new List<Server>();
            servers.AddRange(section.QueryOver<Server>().Where(i => i.User == LoggedUser).List());
            return servers;
        }

        public static PingReply CheckServer(User LoggedUser, string host)
        {
            var session = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            Server server = LoggedUser.Servers.Where(i => i.Host == host).SingleOrDefault();
            if (server == null)
                throw new Exception("Host não Cadastrado");
            server.LastCheck = DateTime.Now;
            var ping = SendPing(host);
            server.LastStatus = ping.Status;
            session.SaveOrUpdate(server);
            return ping;
        }

        public static PingReply SendPing(string host)
        {
            Ping ping = new Ping();

            var reply = ping.Send(host, 2000);

            return new PingReply
            {
                HostResponse = reply.Address == null ? "" : reply.Address.ToString(),
                Latency = reply.RoundtripTime,
                Status = reply.Status == IPStatus.Success ? "Online" : reply.Status == IPStatus.TimedOut ? "Offline" : reply.Status.ToString()
            };
        }


        public class PingReply
        {
            public string HostResponse { get; set; }
            public long Latency { get; set; }
            public string Status { get; set; }
        }
    }

}