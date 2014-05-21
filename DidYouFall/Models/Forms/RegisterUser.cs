using DidYouFall.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class RegisterUser
    {
        public User User { get; protected set; }
        public string Error { get; set; }
        public RegisterUser()
        {
            User = new User();
            Error = "";
        }
        public void Setup(string email, string password1, string password2, string name, string company)
        {
            try
            {
                User = new User { Email = email, Name = name, Company = company, Password = ToolBox.Encryption.MD5(password1) };
                Validations.Inputs vldInpt = new Validations.Inputs();
                Validations.DataBase vldDb = new Validations.DataBase();
                vldInpt.EmailString(email);
                vldInpt.PasswordString(password1, password2);
                vldDb.RegisteredEmail(email);

            }
            catch (Exception ex)
            {
                Error = ex.Message;
                User = new User { Email = email, Name = name, Company = company };
                throw;
            }
        }

        public void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Error))
                {
                    var session = DidYouFall.MvcApplication.SessionFactory.GetCurrentSession();
                    session.Save(User);
                }
                else
                    throw new CustomException.ErrorOnRegister();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}