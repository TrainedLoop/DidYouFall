﻿using System;
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
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace DidYouFall.Agent.Forms
{
    public partial class Configuration : Form
    {
        public PC PcInfo { get; set; }
        ConfigurationController config = new ConfigurationController();
        public Configuration(PC pcInfo)
        {
            PcInfo = pcInfo;
            InitializeComponent();
            InitServerConfig(pcInfo);
            InitCheckListHDs(PcInfo);
            InitChrckListServices(PcInfo);

        }

        private void InitServerConfig(PC pcInfo)
        {
            textBoxServer.Text = PcInfo.Server;
            textBoxEmail.Text = PcInfo.Email;
            textBoxPassword.Text = PcInfo.Password;
            if (String.IsNullOrWhiteSpace(pcInfo.Server))
                textBoxServer.Text = "taon.danielporto.net";
            if (String.IsNullOrWhiteSpace(pcInfo.Email))
                textBoxEmail.Text = "seuemail@dominio.com";
            if (String.IsNullOrWhiteSpace(pcInfo.Password))
                textBoxPassword.Text = "123456";
        }

        private void InitChrckListServices(PC pcInfo)
        {
            checkedListBoxServices.Items.Clear();
            foreach (var item in pcInfo.Services.OrderBy(i => i.Name))
            {
                checkedListBoxServices.Items.Add(item.Name, item.Monitoring);
            }
        }

        private void InitCheckListHDs(PC pcInfo)
        {
            checkedListBoxHDs.Items.Clear();
            foreach (var item in pcInfo.Drivers.OrderBy(i => i.Volume))
            {
                checkedListBoxHDs.Items.Add(item.Volume + (string.IsNullOrEmpty(item.Label) ? "" : " - " + item.Label), item.Monitoring);
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

        private void btnReloadHD_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("As configurações atuais de monitoramento serão perdidas deseja continuar?", "Perigo!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                PcInfo.LoadDrivers();
                InitCheckListHDs(PcInfo);
            }

        }

        private void btnReloadServices_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("As configurações atuais de monitoramento serão perdidas deseja continuar?", "Perigo!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                PcInfo.LoadServices();
                InitChrckListServices(PcInfo);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            btnConectar.Enabled = false;
            var response = config.TryConectToServer(textBoxServer.Text, textBoxEmail.Text, textBoxPassword.Text);

            if (response == "True")
            {
                MessageBox.Show("Conectado!", "Status de Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(response, "Status de  Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnConectar.Enabled = true;
        }




    }
}
