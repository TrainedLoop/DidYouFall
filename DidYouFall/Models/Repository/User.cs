using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Repository
{
    [ActiveRecord(Schema = "didyoufall")]
    public class Users : ActiveRecordLinqBase<Users>
    {
        [PrimaryKey(PrimaryKeyType.Native, "Id")]
        public int Id { get; set; }

        [Property(Column = "Email")]
        public string Email { get; set; }

        [Property(Column = "Password")]
        public string Password { get; set; }

        [Property(Column = "Name")]
        public string Name { get; set; }

        [Property(Column = "Company")]
        public string Company { get; set; }

        public static void LoginUser(string Email, string Password)
        {
            try
            {
                Password = ToolBox.Encryption.MD5(Password);
                Users query = Users.Queryable.Where(i => i.Email == Email && i.Password == Password).SingleOrDefault();
                if (query == null)
                    throw new Exception("Email ou senha Invalidos");
                HttpCookie MyCookie = new HttpCookie("BarretCookie");
                MyCookie["Email"] = query.Email;
                MyCookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(MyCookie);

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public static Users GetLoggedUser()
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["BarretCookie"];
            if (MyCookie == null)
            {
                return null;
            }
            else
            {
                Users user = Users.Queryable.Where(i => i.Email == MyCookie["Email"]).SingleOrDefault();
                return user;
            }
        }
        public static void Logoff()
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies["BarretCookie"];

            if (MyCookie != null)
            {
                Users query = Users.Queryable.Where(i => i.Email == MyCookie["Email"]).SingleOrDefault();
                MyCookie["Email"] = query.Email;
                MyCookie.Expires = DateTime.Now.AddMilliseconds(500);
                HttpContext.Current.Response.Cookies.Add(MyCookie);
            }

        }
    }
}