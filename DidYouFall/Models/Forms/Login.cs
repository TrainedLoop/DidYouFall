using DidYouFall.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class Login
    {
        private Login() { }
        public Login(string email, string password)
        {
            try
            {
                Validations.Inputs vld = new Validations.Inputs();
                vld.EmailString(email);
                vld.PasswordString(password);
                Users.LoginUser(email, password);
            }
            catch (Exception)
            {
                throw new Exception("Email ou senha Invalidos");
            }
        }


    }
}