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

        public Login(){}

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
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["BarretCookieTryLogin"];
            return MyCookie == null? false : int.Parse(MyCookie["Trys"])>3;
        }

        private void TryCookie()
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["BarretCookieTryLogin"];
            if (MyCookie == null)
                MyCookie = new HttpCookie("BarretCookieTryLogin");
            MyCookie["Trys"] = MyCookie["Trys"] == null ? "1" : ((int.Parse(MyCookie["Trys"]) + 1).ToString());
            MyCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(MyCookie);
        }

    }
}