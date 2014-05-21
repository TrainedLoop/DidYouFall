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
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["BarretCookie"];
            if (MyCookie == null)
            {
                return null;
            }
            else
            {
                var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
                return section.QueryOver<User>().Where(i => i.Email == MyCookie["Email"]).SingleOrDefault();
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
                HttpCookie MyCookie = new HttpCookie("BarretCookie");
                MyCookie["Email"] = query.Email;
                MyCookie.Expires = DateTime.Now.AddDays(ValidateCookieTimes);
                HttpContext.Current.Response.Cookies.Add(MyCookie);
            }
            catch (Exception)
            {
                throw new Exception("Senha ou usuario invalidos");
            }

        }
        public static void Logoff()
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["BarretCookie"];
            var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
            if (MyCookie != null)
            {
                User query = section.QueryOver<User>().Where(i => i.Email == MyCookie["Email"]).SingleOrDefault();
                MyCookie["Email"] = query.Email;
                MyCookie.Expires = DateTime.Now.AddMilliseconds(500);
                HttpContext.Current.Response.Cookies.Add(MyCookie);
            }

        }
    }
}