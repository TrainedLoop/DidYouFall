using DidYouFall.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DidYouFall.Controllers
{
    public class ServerController : Controller
    {
        
        public ActionResult Register()
        {
            if (UsersUtilities.GetLoggedUser() == null)
                return Redirect("~/User/Login");

            return View();
        }
	}
}