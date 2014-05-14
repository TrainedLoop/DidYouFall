using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DidYouFall.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult UserLogin(string password, string email)
        {
            return View();
        }
	}
}