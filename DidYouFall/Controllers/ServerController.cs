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
        public async Task<ActionResult> Register(string name, string ip, string contactEmail, Times verificationTime)
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");

            RegisterServer ServerToRegister = new RegisterServer();
            try
            {
                ServerToRegister.Setup(name, ip, contactEmail, verificationTime, loggedUser);
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

        public ActionResult ShowServers()
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");
            if (loggedUser.Servers.Count == 0)
                return RedirectToAction("Register");
            return View(loggedUser.Servers);
        }

        [HttpPost]
        public ActionResult AddPorts(int server, int port)
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");
            try
            {
                new AddPort(loggedUser, server, port);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("ShowServers", loggedUser.Servers);
        }

        public ActionResult Monitor()
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");
            if (loggedUser.Servers.Count == 0)
                return RedirectToAction("Register");



            return View(ServerUtilities.GetAllServers(loggedUser));
        }
        public ActionResult CheckOneServer(string IP)
        {
            var loggedUser = UsersUtilities.GetLoggedUser();
            if (loggedUser == null)
                return Redirect("~/User/Login");
            return Json(ServerUtilities.CheckServer(loggedUser, IP), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckPort(int port, int server)
        {
            try
            {
                var loggedUser = UsersUtilities.GetLoggedUser();
                if (loggedUser == null)
                    return Redirect("~/User/Login");
                ServerUtilities.CheckPort(loggedUser, loggedUser.Servers.Where(i => i.Id == server).FirstOrDefault(), port);
                return Json(new {Port=port, Status = "Aberta" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Port = port, Status = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}