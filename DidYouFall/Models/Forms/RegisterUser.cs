using DidYouFall.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class RegisterUser
    {
        protected RegisterUser() { }

        public RegisterUser(string email, string password1, string password2, string name, string company)
        {

            Validations.Inputs vldInpt = new Validations.Inputs();
            Validations.DataBase vldDb = new Validations.DataBase();
            vldInpt.EmailString(email);
            vldInpt.PasswordString(password1, password2);
            vldDb.RegisteredEmail(email);
            Users user = new Users { Email = email, Name = name, Password = password1, Company = company};
            user.Save();
        }
    }
}