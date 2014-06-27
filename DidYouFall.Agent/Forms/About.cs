using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DidYouFall.Agent.Forms
{
    public partial class About : Form
    {
#warning config
        string LinkToAutor = "http://www.danielporto.net";
        string LinkToApp = "http://taon.danielporto.net";
        public About()
        {
            InitializeComponent();
            
        }

        private void LinkLblAutor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LinkToAutor);
        }

        private void linkLblTittle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LinkToApp);
        }
    }
}
