using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Runtime.Serialization;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace DidYouFall.Agent.Info
{
    [Serializable()]
    public class PC
    {
        public string ContactEmail { get; set; }
        public string Server { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ComputarName { get; set; }
        public string CpuUsage { get; set; }
        public long PhysicalAvailableMemoryInMiB { get; set; }
        public long GetTotalMemoryInMiB { get; set; }
        public int CheckTime { get; set; }

        public List<Driver> Drivers { get; set; }
        public List<Service> Services { get; set; }

        public PC()
        {
            ComputarName = SystemInformation.ComputerName;
            Drivers = new List<Driver>();
            Services = new List<Service>();
            PerformanceCounter CPU = new PerformanceCounter();
            PhysicalAvailableMemoryInMiB = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            GetTotalMemoryInMiB = PerformanceInfo.GetTotalMemoryInMiB();
            CpuUsage = GetCPUUsage(CPU);
            LoadDrivers();
            LoadServices();
            CheckTime = 5;
        }

        public void LoadDrivers()
        {
            Drivers.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Drivers.Add(new Driver
                    {
                        FreeSpace = (drive.TotalFreeSpace / 1024) / 1024,
                        Label = drive.VolumeLabel,
                        TotalSpace = (drive.TotalSize / 1024) / 1024,
                        Volume = drive.Name,
                        Status = drive.IsReady,
                        Format = drive.DriveFormat,
                        Monitoring = false
                    });
                }
            }

        }

        public void LoadServices()
        {
            Services.Clear();
            foreach (var item in ServiceController.GetServices())
            {
                Services.Add(new Service { Name = item.DisplayName, Status = item.Status.ToString(), Monitoring = false });
            }

        }

        public void SendInformation()
        {
            while (true)
            {
                try
                {
                    PerformanceCounter CPU = new PerformanceCounter();
                    var monitoratedDrivers = this.Drivers.Where(i => i.Monitoring == true).ToList();
                    foreach (var item in this.Drivers.Where(i => i.Monitoring == false).ToList())
                    {
                        monitoratedDrivers.Add(new Driver { Volume = item.Volume, Monitoring = item.Monitoring });
                    }
                    var monitoratedServices = this.Services.Where(i => i.Monitoring == true).ToList();
                    foreach (var item in this.Services.Where(i => i.Monitoring == false).ToList())
                    {
                        monitoratedServices.Add(new Service {  Name = item.Name, Monitoring = item.Monitoring });
                    }
                    var pcIntoToSend = new PC()
                    {
                        Server = this.Server,
                        Email = this.Email,
                        ContactEmail = this.ContactEmail,
                        Password = this.Password,
                        ComputarName = SystemInformation.ComputerName,
                        Drivers = monitoratedDrivers,
                        Services = monitoratedServices,

                        PhysicalAvailableMemoryInMiB = PerformanceInfo.GetPhysicalAvailableMemoryInMiB(),
                        GetTotalMemoryInMiB = PerformanceInfo.GetTotalMemoryInMiB(),
                        CpuUsage = GetCPUUsage(CPU)
                    };
                    var jsonPcInfo = JsonConvert.SerializeObject(pcIntoToSend);

                    WebClient client = new WebClient();
                    var values = new NameValueCollection();
                    values["JsonPcInfo"] = jsonPcInfo;
                    var response = client.UploadValues("http://" + pcIntoToSend.Server + "/agent/PcInfo", "POST", values);
                    var responseString = Encoding.Default.GetString(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Thread.Sleep(this.CheckTime * 60 * 1000);

            }

        }
        private void DriverCheck()
        {
            var ActiveDrivers = Drivers.Where(i => i.Monitoring == true).Select(i => i.Volume);

            foreach (var item in DriveInfo.GetDrives().Where(i => i.IsReady == true && ActiveDrivers.Contains(i.Name)))
            {
                Drivers.Remove(Drivers.Where(i => i.Volume == item.Name).FirstOrDefault());
                Drivers.Add(new Driver
                {
                    FreeSpace = (item.TotalFreeSpace / 1024) / 1024,
                    Label = item.VolumeLabel,
                    TotalSpace = (item.TotalSize / 1024) / 1024,
                    Volume = item.Name,
                    Status = item.IsReady,
                    Format = item.DriveFormat,
                    Monitoring = true
                });
            }
        }

        private void ServiceCheck()
        {
            var ActiveServices = Services.Where(i => i.Monitoring == true).Select(i => i.Name);
            foreach (var item in ServiceController.GetServices().Where(i => ActiveServices.Contains(i.DisplayName)))
            {
                Services.Remove(Services.Where(i => i.Name == item.DisplayName).FirstOrDefault());
                Services.Add(new Service { Name = item.DisplayName, Monitoring = true, Status = item.Status.ToString() });
            }
        }

        private static string GetCPUUsage(PerformanceCounter CPU)
        {
            CPU.CategoryName = "Processor";
            CPU.CounterName = "% Processor Time";
            CPU.InstanceName = "_Total";
            return CPU.NextValue() + "%";
        }

        private static class PerformanceInfo
        {
            [DllImport("psapi.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

            [StructLayout(LayoutKind.Sequential)]
            public struct PerformanceInformation
            {
                public int Size;
                public IntPtr CommitTotal;
                public IntPtr CommitLimit;
                public IntPtr CommitPeak;
                public IntPtr PhysicalTotal;
                public IntPtr PhysicalAvailable;
                public IntPtr SystemCache;
                public IntPtr KernelTotal;
                public IntPtr KernelPaged;
                public IntPtr KernelNonPaged;
                public IntPtr PageSize;
                public int HandlesCount;
                public int ProcessCount;
                public int ThreadCount;
            }

            public static Int64 GetPhysicalAvailableMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }

            public static Int64 GetTotalMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }
        }

    }
    [Serializable()]
    public class Driver
    {
        public string Label { get; set; }
        public long FreeSpace { get; set; }
        public long TotalSpace { get; set; }
        public string Volume { get; set; }
        public bool Status { get; set; }
        public string Format { get; set; }
        public bool Monitoring { get; set; }
    }
    [Serializable()]
    public class Service
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public bool Monitoring { get; set; }
    }
}
