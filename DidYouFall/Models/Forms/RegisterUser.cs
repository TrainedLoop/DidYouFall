using DidYouFall.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class RegisterUser
    {
        public Users User { get; protected set; }
        public string Error { get;  set; }
        public RegisterUser()
        {
            User = new Users();
            Error = "";
        }
        public void Setup(string email, string password1, string password2, string name, string company)
        {

            try
            {                
                Validations.Inputs vldInpt = new Validations.Inputs();
                Validations.DataBase vldDb = new Validations.DataBase();
                vldInpt.EmailString(email);
                vldInpt.PasswordString(password1, password2);
                vldDb.RegisteredEmail(email);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                User = new Users { Email = email, Name = name,  Company = company };
                throw;
            }

          
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(Error))
                User.Save();
            else
                throw new CustomException.ErrorOnRegister();
        }
    }
}