using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DidYouFall.Models.Forms;

namespace DidYouFall.Controllers
{
    public class AgentController : Controller
    {
        // GET: Agent
        public ActionResult AgentConfigConection(string email, string password)
        {
            Login login = new Login();
            try
            {
                login.LoginUser(email, password);
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}