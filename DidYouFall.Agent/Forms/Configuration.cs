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
using DidYouFall.Agent.Controllers;

namespace DidYouFall.Agent.Forms
{
    public partial class Configuration : Form
    {
        public PC PcInfo { get; set; }
        ConfigurationController config = new ConfigurationController();
        public Configuration(PC pcInfo)
        {
            InitializeComponent();
            PcInfo = pcInfo;

            foreach (var item in pcInfo.Drivers.OrderBy(i => i.Volume))
            {
                checkedListBoxHDs.Items.Add(item.Volume + (string.IsNullOrEmpty(item.Label) ? "" : " - " + item.Label), item.Monitoring);
            }
            foreach (var item in pcInfo.Services.OrderBy( i=> i.Name))
            {
                checkedListBoxServices.Items.Add(item.Name, item.Monitoring);
            }

        }

        private void buttonClearAllHDs_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxHDs.Items.Count; i++)
            {
                checkedListBoxHDs.SetItemChecked(i, false);
            }
        }

        private void buttonSelectAllHDs_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxHDs.Items.Count; i++)
            {
                checkedListBoxHDs.SetItemChecked(i, true);
            }
        }

        private void buttonClearAllServices_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxServices.Items.Count; i++)
            {
                checkedListBoxServices.SetItemChecked(i, false);
            }

        }

        private void buttonSelectAllServices_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxServices.Items.Count; i++)
            {
                checkedListBoxServices.SetItemChecked(i, true);
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            config.ApplyConfig(
                PcInfo,
                textBoxServer,
                textBoxEmail,
                textBoxPassword,
                checkedListBoxHDs,
                checkedListBoxServices
                );

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            config.ApplyConfig(
                PcInfo,
                textBoxServer,
                textBoxEmail,
                textBoxPassword,
                checkedListBoxHDs,
                checkedListBoxServices
                );

            this.Dispose();

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FileController.LoadConfig();
        }


    }
}
