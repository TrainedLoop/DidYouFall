using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DidYouFall.Models.Forms;
using DidYouFall.Models.Utilities;
using DidYouFall.Repository;
using Newtonsoft.Json;

namespace DidYouFall.Controllers
{
    public class AgentController : Controller
    {
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
            var pcInfo = JsonConvert.DeserializeObject<AgentUtilities.PCInfoPost>(JsonPcInfo);
            Login login = new Login();
            try
            {
                login.LoginUser(pcInfo.Email, pcInfo.Password);
                var user = UsersUtilities.GetLoggedUser();
                var agent = new AgentUtilities();
                agent.UpdatePcInfo(pcInfo, user);
                return Json("Save Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AgentPcs()
        {
            var user = UsersUtilities.GetLoggedUser();
            if (user== null)
                return Redirect("~/User/Login");
            return View(user.AgentsInfo);
        }
    }
}