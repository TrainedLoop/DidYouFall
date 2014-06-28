using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DidYouFall.Agent.TrayIcon;

namespace DidYouFall.Agent
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (AgentIcon agentIcon = new AgentIcon())
            {
                agentIcon.Display();
                Application.Run();
            }
        }
    }
}
