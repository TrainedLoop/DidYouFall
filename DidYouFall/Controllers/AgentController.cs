using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DidYouFall.Models.Forms;
using Newtonsoft.Json;

namespace DidYouFall.Controllers
{
    public class AgentController : Controller
    {
        public class PC
        {
            public string Server { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ComputarName { get; set; }
            public string CpuUsage { get; set; }
            public long PhysicalAvailableMemoryInMiB { get; set; }
            public long GetTotalMemoryInMiB { get; set; }

            public List<Driver> Drivers { get; set; }
            public List<Service> Services { get; set; }
        }

        public class Driver
        {
            public string Label { get; set; }
            public long FreeSpace { get; set; }
            public long TotalSpace { get; set; }
            public string Volume { get; set; }
            public bool Status { get; set; }
            public string Format { get; set; }
            public bool Monitoring { get; set; }
        }

        public class Service
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public bool Monitoring { get; set; }
        }


        // GET: Agent
        public ActionResult ConfigConection(string email, string password)
        {
            Login login = new Login();
            try
            {
                login.LoginUser(email, password);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PcInfo(string JsonPcInfo)
        {
            var pcInfo = JsonConvert.DeserializeObject<PC>(JsonPcInfo);
            Login login = new Login();
            try
            {
                login.LoginUser(pcInfo.Email, pcInfo.Password);
                return Json("de boa", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}