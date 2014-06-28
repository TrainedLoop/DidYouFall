using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DidYouFall.Agent
{
    public class PCInfo
    {
        public string ComputarName { get; set; }
        public List<Driver> Drivers { get; set; }
        public string CpuUsage { get; set; }
        public long PhysicalAvailableMemoryInMiB { get; set; }
        public long GetTotalMemoryInMiB { get; set; }

        public PCInfo()
        {
            ComputarName = SystemInformation.ComputerName;
            Drivers = new List<Driver>();
            PerformanceCounter CPU = new PerformanceCounter();
            PhysicalAvailableMemoryInMiB = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            GetTotalMemoryInMiB = PerformanceInfo.GetTotalMemoryInMiB();
            CpuUsage = GetCPUUsage(CPU);


            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Drivers.Add(new Driver
                    {
                        FreeSpace = (drive.TotalFreeSpace / 1024)/1024,
                        Label = drive.VolumeLabel,
                        TotalSpace = (drive.TotalSize / 1024)/1024,
                        Volume = drive.Name,
                        Status = drive.IsReady,
                        Format = drive.DriveFormat
                    });
                }
            }
        }
        public static string GetCPUUsage(PerformanceCounter CPU)
        {
            CPU.CategoryName = "Processor";
            CPU.CounterName = "% Processor Time";
            CPU.InstanceName = "_Total";
            return CPU.NextValue() + "%";
        }
        public class Driver
        {
            public string Label { get; set; }
            public long FreeSpace { get; set; }
            public long TotalSpace { get; set; }
            public string Volume { get; set; }
            public bool Status { get; set; }
            public string Format { get; set; }
        }
        public static class PerformanceInfo
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

}
