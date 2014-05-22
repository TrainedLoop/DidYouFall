using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DidYouFall.Models.Forms;
using DidYouFall.Models;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using System.Threading.Tasks;
using DidYouFall.Models.Utilities;

namespace DidYouFall.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(string email, string password1, string password2, string name, string company)
        {
            RegisterUser userToRegister = new RegisterUser();
            try
            {
                userToRegister.Setup(email, password1, password2, name, company);
                RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
                if (String.IsNullOrEmpty(recaptchaHelper.Response))
                    throw new CustomException.EmptyRecaptcha();
                RecaptchaVerificationResult recaptchaResult = await recaptchaHelper.VerifyRecaptchaResponseTaskAsync();
                if (recaptchaResult != RecaptchaVerificationResult.Success)
                    throw new CustomException.Recaptcha();
                userToRegister.Save();
                return View();
            }
            catch (Exception ex)
            {
                if (ex is CustomException.EmptyRecaptcha || ex is CustomException.Recaptcha)
                    userToRegister.Error = ex.Message;
                return View(userToRegister);
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            Login login = new Login();
            try
            {
                if (login.RecaptchaTime())
                {
                    RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
                    if (String.IsNullOrEmpty(recaptchaHelper.Response))
                        throw new CustomException.EmptyRecaptcha();
                    RecaptchaVerificationResult recaptchaResult = await recaptchaHelper.VerifyRecaptchaResponseTaskAsync();
                    if (recaptchaResult != RecaptchaVerificationResult.Success)
                        throw new CustomException.Recaptcha();
                }
                login.LoginUser(email, password);
            }

            catch (Exception ex)
            {
                if (ex is CustomException.EmptyRecaptcha || ex is CustomException.Recaptcha)
                    login.Error = ex.Message;
                return View(login);
            }
            return Redirect("/home/index");
        }


        public ActionResult Logoff()
        {
            UsersUtilities.Logoff();
            return Redirect("/home/index");
        }

    }
}