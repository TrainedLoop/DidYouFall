using DidYouFall.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DidYouFall.Models.Forms;

namespace DidYouFall.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/
        public ActionResult ServerLog(int? Id)
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");
            ServerLogs logs = new ServerLogs(loggedUser);
            if(Id != null)
            {
                logs.SelectServer(Id.Value);
            }


            return View(logs);
        }
	}
}