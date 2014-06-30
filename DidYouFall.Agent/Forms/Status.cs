using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DidYouFall.Agent.Info;

namespace DidYouFall.Agent.Forms
{
    public partial class Status : Form
    {
        public Status(PC pcInfo)
        {
            InitializeComponent();
            LblCPU.Text = pcInfo.CpuUsage;
            LblTotalMemory.Text = pcInfo.GetTotalMemoryInMiB.ToString() + " MB";
            LblAvaibleMemory.Text = pcInfo.PhysicalAvailableMemoryInMiB.ToString()+" MB";
            DgvHD.ColumnCount = 5;
            DgvHD.Columns[0].Name = "Volume";
            DgvHD.Columns[1].Name = "Label";
            DgvHD.Columns[2].Name = "Espaço Total (MB)";
            DgvHD.Columns[3].Name = "Espaço Livre (MB)";
            DgvHD.Columns[4].Name = "Formato";

            foreach (var item in pcInfo.Drivers)
            {
                string[] row = new string[] { item.Volume, item.Label, item.TotalSpace.ToString(), item.FreeSpace.ToString(), item.Format };
                DgvHD.Rows.Add(row);
            }
        }
    }
}
