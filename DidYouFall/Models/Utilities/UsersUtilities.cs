using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DidYouFall.Models.Forms;

namespace DidYouFall.Models.Utilities
{
    public class UsersUtilities
    {
        const int ValidateCookieTimes = 1; // In Days
        public static User GetLoggedUser()
        {
            string cookieEmail;
            try
            {
                cookieEmail = HttpContext.Current.Request.Cookies.Get("CookieDidYouFall").Values.Get("email");
                var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
                return section.QueryOver<User>().Where(i => i.Email == cookieEmail).SingleOrDefault();
            }
            catch (NullReferenceException)
            {
                return null;
            }

        }

        public static void Login(string email, string password)
        {
            try
            {
                Models.Forms.Validations.Inputs vld = new Forms.Validations.Inputs();
                vld.EmailString(email);
                vld.PasswordString(password);
                var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
                User query = section.QueryOver<User>().Where(i => i.Email == email && i.Password == ToolBox.Encryption.MD5(password)).SingleOrDefault();
                if (query == null)
                    throw new Exception();
                SetLoginCookie(email);
                var cookieEmail = HttpContext.Current.Request.Cookies.Get("CookieDidYouFall").Values.Get("email");


            }
            catch (Exception)
            {
                throw new Exception("Senha ou usuario invalidos");
            }

        }
        public static void Logoff()
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["CookieDidYouFall"];
            var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            if (MyCookie["email"] != null)
            {
                User query = section.QueryOver<User>().Where(i => i.Email == MyCookie["Email"]).SingleOrDefault();
                MyCookie.Values["Email"] = query.Email;
                MyCookie.Expires = DateTime.Now.AddMilliseconds(500);
                HttpContext.Current.Response.Cookies.Add(MyCookie);
            }

        }


        public static void SetLoginCookie(string email)
        {
            HttpCookie LoginCookie = HttpContext.Current.Request.Cookies["CookieDidYouFall"];
            if (LoginCookie == null)
                LoginCookie = new HttpCookie("CookieDidYouFall");
            LoginCookie.Values["LoginTrys"] = email;
            LoginCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(LoginCookie);
        }


       


        
    }
}