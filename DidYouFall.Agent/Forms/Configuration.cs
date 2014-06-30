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
    public partial class Configuration : Form
    {
        public Configuration(PC pcInfo)
        {
            InitializeComponent();

            foreach (var item in pcInfo.Drivers)
            {
                checkedListBoxHDs.Items.Add(item.Volume + (string.IsNullOrEmpty(item.Label) ? "" : " - " + item.Label), item.Status);
            }
            foreach (var item in pcInfo.Services)
            {
                checkedListBoxServices.Items.Add(item.Name, item.Monitoring);
            }

        }
    }
}
