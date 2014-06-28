using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DidYouFall.Agent.Properties;

namespace DidYouFall.Agent.TrayIcon
{
    public class AgentIcon : IDisposable
    {
        NotifyIcon notifyIcon;

        public AgentIcon()
        {
            notifyIcon = new NotifyIcon();
        }

        public void Display()
        {		
            //notifyIcon.MouseClick += new MouseEventHandler(ni_MouseClick);
            notifyIcon.Icon = Resources.Icon;
            notifyIcon.Text = "Agente Did You Fall";
            notifyIcon.Visible = true;

            notifyIcon.ContextMenuStrip = new Menu().Create();
        }
        public void Dispose()
        {
            notifyIcon.Dispose();
        }


    }
}
