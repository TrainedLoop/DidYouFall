using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DidYouFall.Repository;

namespace DidYouFall.Models.Utilities
{
    public class AgentUtilities
    {
        public class PCInfoPost
        {

            public string Email { get; set; }
            public string Password { get; set; }
            public string ComputarName { get; set; }
            public string CpuUsage { get; set; }
            public string ContactEmail { get; set; }

            public long PhysicalAvailableMemoryInMiB { get; set; }
            public long GetTotalMemoryInMiB { get; set; }

            public List<Driver> Drivers { get; set; }
            public List<Service> Services { get; set; }
        }

        public void UpdatePcInfo(PCInfoPost pcInfo, Repository.User user)
        {
            try
            {
                var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
                var DbPcInfo = section.QueryOver<AgentInfo>().Where(i => i.User == user && i.ComputarName == pcInfo.ComputarName).SingleOrDefault();
                if (DbPcInfo != null)
                {
                    AddPCInfo(pcInfo, DbPcInfo);
                    AddDriverInfo(pcInfo, DbPcInfo);
                    AddServiceInfo(pcInfo, DbPcInfo);
                    section.SaveOrUpdate(DbPcInfo);
                }
                else
                {
                    user.AgentsInfo.Add(new AgentInfo
                    {
                        ComputarName = pcInfo.ComputarName,
                        ContactEmail = pcInfo.ContactEmail,
                        CpuUsage = pcInfo.CpuUsage,
                        GetTotalMemoryInMiB = pcInfo.GetTotalMemoryInMiB,
                        PhysicalAvailableMemoryInMiB = pcInfo.PhysicalAvailableMemoryInMiB,
                        LastCheck = DateTime.Now,
                        User = user,
                        Drivers = pcInfo.Drivers,
                        Services = pcInfo.Services,
                    });
                    section.SaveOrUpdate(user);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void AddPCInfo(PCInfoPost pcInfo, AgentInfo DbPcInfo)
        {
            DbPcInfo.ContactEmail = pcInfo.ContactEmail;
            DbPcInfo.CpuUsage = pcInfo.CpuUsage;
            DbPcInfo.GetTotalMemoryInMiB = pcInfo.GetTotalMemoryInMiB;
            DbPcInfo.PhysicalAvailableMemoryInMiB = pcInfo.PhysicalAvailableMemoryInMiB;
            DbPcInfo.LastCheck = DateTime.Now;
        }

        private void AddServiceInfo(PCInfoPost pcInfo, AgentInfo DbPcInfo)
        {
            foreach (var item in pcInfo.Services)
            {
                var dbServices = DbPcInfo.Services.Where(i => i.Name == item.Name).SingleOrDefault();
                if (dbServices != null)
                {
                    if (item.Monitoring == true)
                    {
                        dbServices.Status = item.Status;
                    }
                    else
                    {
                        dbServices.Monitoring = false;
                    }
                }
                else if (item.Monitoring)
                {
                    DbPcInfo.Services.Add(item);
                }
            }
        }

        private void AddDriverInfo(PCInfoPost pcInfo, AgentInfo DbPcInfo)
        {
            foreach (var item in pcInfo.Drivers)
            {
                var dbDriver = DbPcInfo.Drivers.Where(i => i.Volume == item.Volume).SingleOrDefault();
                if (dbDriver != null)
                {
                    if (item.Monitoring == true)
                    {
                        dbDriver.Status = item.Status;
                        dbDriver.TotalSpace = item.TotalSpace;
                        dbDriver.Format = item.Format;
                        dbDriver.FreeSpace = item.FreeSpace;
                        dbDriver.Volume = item.Volume;
                    }
                    else
                    {
                        dbDriver.Monitoring = false;
                    }
                }
                else if (item.Monitoring)
                {

                    DbPcInfo.Drivers.Add(item);
                }
            }
        }
    }
}