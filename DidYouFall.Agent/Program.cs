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
        public static string Version = "0.1";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (AgentIcon agentIcon = new AgentIcon())
            {
                agentIcon.Display();

                // Make sure the application runs!
                Application.Run();
            }
        }
    }
}
