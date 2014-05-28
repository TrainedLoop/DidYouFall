using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;
using System.Net.Sockets;

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
            SetLog(server, ping);
            server.Uptime = SetTime(server);
            session.SaveOrUpdate(server);
            ping.Uptime = Convert.ToInt32(server.Uptime);
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

        private static void SetLog(Server server, PingReply ping)
        {
            var activeLog = server.Logs.Where(i => i.Closed == false).FirstOrDefault();
            var session = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            if (activeLog == null)
            {
                var newlog = new ServerLog
                {
                    Closed = false,
                    LogAt = DateTime.Now,
                    Server = server,
                };
                if (ping.Status == "Online")
                    newlog.UpAt = DateTime.Now;
                else
                    newlog.DownAt = DateTime.Now;

                newlog.Closed = false;
                server.Logs.Add(newlog);
            }
            else
            {
                if (ping.Status == "Online")
                {
                    if (activeLog.UpAt == null)
                    {
                        activeLog.UpAt = DateTime.Now;
                        activeLog.Closed = true;
                        var newLog = new ServerLog
                        {
                            Closed = false,
                            LogAt = DateTime.Now,
                            Server = server,
                            UpAt = DateTime.Now
                        };
                        server.Logs.Add(newLog);
                    }
                }
                else
                {
                    if (activeLog.DownAt == null)
                    {
                        activeLog.DownAt = DateTime.Now;
                        activeLog.Closed = true;
                        var newLog = new ServerLog
                        {
                            Closed = false,
                            LogAt = DateTime.Now,
                            Server = server,
                            DownAt = DateTime.Now
                        };
                        server.Logs.Add(newLog);
                    }
                }

            }

        }

        public static void CheckPort(User LoggedUser, Server server, int port)
        {
            try
            {
                ConectToPort(server.Host, port);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ConectToPort(string ip, int port)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);
            }
            catch (Exception)
            {
                throw new Exception("Falha");
            }

        }

        public class PingReply
        {
            public string HostResponse { get; set; }
            public long Latency { get; set; }
            public string Status { get; set; }
            public double Uptime { get; set; }
        }

        public static double SetTime(Server server)
        {
            var uplogs = server.Logs.Where(i => i.Closed == true && i.UpAt < i.DownAt).ToList();
            var downlogs = server.Logs.Where(i => i.Closed == true && i.UpAt > i.DownAt);
            var actual = server.Logs.Where(i => i.Closed == false).FirstOrDefault();
            TimeSpan? uptime = TimeSpan.Zero;
            TimeSpan? downtime = TimeSpan.Zero;
            foreach (var item in uplogs)
            {
                uptime = uptime + (item.DownAt - item.UpAt);
            }
            foreach (var item in downlogs)
            {
                downtime = uptime + (item.UpAt - item.DownAt);
            }
            if (actual.UpAt != null)
                uptime = uptime + (DateTime.Now - actual.LogAt);
            if (actual.DownAt != null)
                downtime = uptime + (DateTime.Now - actual.LogAt);

            var total = uptime + downtime;

            return uptime.Value.TotalMinutes / (total.Value.TotalMinutes / 100);

        }
    }

}