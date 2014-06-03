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
        public ViewLogs Logs { get; set; }

        public ServerLogs(User LoggedUser)
        {
            Servers = LoggedUser.Servers.ToList();
        }

        public void SelectServer(int Id)
        {
            var selectedLogs = Servers.Where(i => i.Id == Id).FirstOrDefault().Logs.ToList();
            Logs = new ViewLogs(selectedLogs);
        }

        public class ViewLogs
        {
            public int ServerId { get; set; }
            public string ServerName { get; private set; }
            public string ServerIp { get; private set; }
            public double ServerUptime { get; private set; }
            public List<Status> Status { get; private set; }


            public  ViewLogs(List<ServerLog> log)
            {
                if (Status == null)
                {
                    Status = new List<Status>();
                }

                if (ServerIp == null || ServerName == null)
                {
                    ServerId = log.FirstOrDefault().Server.Id;
                    ServerName = log.FirstOrDefault().Server.Name;
                    ServerIp = log.FirstOrDefault().Server.IP;
                    ServerUptime = log.FirstOrDefault().Server.Uptime;
                    foreach (var item in log)
                    {
                        Status.Add(new Status(item));
                    }
                }

            }


        }
        public class Status
        {
            public DateTime? DownAt { get; private set; }
            public DateTime? UpAt { get; private set; }
            public TimeSpan? Time { get; private set; }
            public string Description { get; private set; }

            public Status(ServerLog log)
            {
                DownAt = log.DownAt;
                UpAt = log.UpAt;

                if (DownAt == null)
                {
                    Time = DateTime.Now - UpAt;
                    Description = "Online";
                }

                else if (UpAt == null)
                {
                    Time = DateTime.Now - DownAt;
                    Description = "Offline";
                }


                else if (DownAt > UpAt)
                {
                    Time = DownAt - UpAt;
                    Description = "Online";
                }
                if (DownAt < UpAt)
                {
                    Time = UpAt - DownAt;
                    Description = "Offline";
                }
            }
        }


    }

}
