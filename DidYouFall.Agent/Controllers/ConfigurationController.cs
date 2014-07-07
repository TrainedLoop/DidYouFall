using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DidYouFall.Agent.Info;
using System.Windows.Forms;

namespace DidYouFall.Agent.Controllers
{
    public class ConfigurationController
    {
        public void ApplyConfig(PC pcInfo, TextBox textBoxServer, TextBox textBoxEmail, TextBox textBoxPassword, CheckedListBox checkedListBoxHDs, CheckedListBox checkedListBoxServices)
        {
            pcInfo.Server = textBoxServer.Text;
            pcInfo.Email = textBoxEmail.Text;
            pcInfo.Password = textBoxPassword.Text;
            foreach (var item in pcInfo.Drivers)
            {
                item.Monitoring = false;
            }
            foreach (var HDs in checkedListBoxHDs.CheckedItems)
            {
                pcInfo.Drivers.Where(i => i.Volume.Contains(HDs.ToString().Substring(0, 3))).FirstOrDefault().Monitoring = true;
            }
            foreach (var item in pcInfo.Services)
            {
                item.Monitoring = false;
            }
            foreach (var services in checkedListBoxServices.CheckedItems)
            {
                pcInfo.Services.Where(i => i.Name == services.ToString()).FirstOrDefault().Monitoring = true;
            }
            FileController.SaveConfig();
        }
    }
}
