using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DidYouFall.Models.Forms;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using System.Threading.Tasks;

namespace DidYouFall.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        //public ActionResult Login(string password, string email)
        //{
        //    new Login(email, password);
        //    return View();
        //}

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
                return View(userToRegister);
            }

        }

    }
}