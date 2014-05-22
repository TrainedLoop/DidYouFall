using DidYouFall.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class Login
    {
        public string Error { get; set; }
        public string Email { get; protected set; }

        public Login() { }

        public void LoginUser(string email, string password)
        {
            try
            {
                UsersUtilities.Login(email, password);
            }
            catch (Exception ex)
            {
                Email = email;
                Error = ex.Message;
                TryCookie();
                throw;
            }
        }
        public bool RecaptchaTime()
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["TryCookie"];
            return MyCookie == null ? false : int.Parse(MyCookie["LoginTrys"]) > 3;
        }

        private void TryCookie()
        {
            HttpCookie TryCookie = HttpContext.Current.Request.Cookies["TryCookie"];
            if (TryCookie == null)
                TryCookie = new HttpCookie("TryCookie");
            TryCookie.Values["LoginTrys"] = TryCookie.Values["LoginTrys"] == null ? "1" : ((int.Parse(TryCookie["LoginTrys"]) + 1).ToString());
            TryCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(TryCookie);
        }

    }
}