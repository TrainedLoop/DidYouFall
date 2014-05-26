using DidYouFall.Models.Forms;
using DidYouFall.Models.Utilities;
using DidYouFall.Repository;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using System.Threading.Tasks;
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
        [HttpPost]
        public async Task<ActionResult> Register(string name, string host, string contactEmail, Times verificationTime)
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");

            RegisterServer ServerToRegister = new RegisterServer();
            try
            {
                ServerToRegister.Setup(name, host, contactEmail, verificationTime, loggedUser);
                RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
                if (String.IsNullOrEmpty(recaptchaHelper.Response))
                    throw new CustomException.EmptyRecaptcha();
                RecaptchaVerificationResult recaptchaResult = await recaptchaHelper.VerifyRecaptchaResponseTaskAsync();
                if (recaptchaResult != RecaptchaVerificationResult.Success)
                    throw new CustomException.Recaptcha();
                ServerToRegister.Save();
                return View(ServerToRegister);
            }
            catch (Exception ex)
            {
                if (ex is CustomException.EmptyRecaptcha || ex is CustomException.Recaptcha)
                    ServerToRegister.Error = ex.Message;
                return View(ServerToRegister);
            }
        }

        public ActionResult AddPort()
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");
            return View(new AddPort(loggedUser));
        }

        public ActionResult Monitor()
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");


            return View(ServerUtilities.GetAllServers(loggedUser));
        }



        public ActionResult CheckOneServer(string host)
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");
            return Json(ServerUtilities.CheckServer(loggedUser,host), JsonRequestBehavior.AllowGet);
        }
       
    }
}