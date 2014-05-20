using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Utilities
{
    public class UsersUtilities
    {
        public static Repository.Users GetLoggedUser()
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["BarretCookie"];
            if (MyCookie == null)
            {
                return null;
            }
            else
            {
                var section = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
                return section.QueryOver<Repository.Users>().Where(i => i.Email == MyCookie["Email"]).SingleOrDefault();
            }

        }
    }
}