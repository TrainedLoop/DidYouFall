using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DidYouFall.Agent.Controllers;
using DidYouFall.Agent.Info;
using DidYouFall.Agent.TrayIcon;

namespace DidYouFall.Agent
{
    static class Program
    {
        public static PC PcInfo { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FileController.LoadConfig();
            Thread checker = new Thread(new ThreadStart(PcInfo.SendInformation));
            checker.Start();
            using (AgentIcon agentIcon = new AgentIcon())
            {
                agentIcon.Display();
                Application.Run();
            }
        }
    }
}
