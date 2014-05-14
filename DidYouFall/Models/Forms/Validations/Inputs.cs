using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DidYouFall.Models.Forms.Validations
{
    public class Inputs
    {
        public void EmailString(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("Digite Seu Email");

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(email))
                throw new Exception("Email Invalido");

        }

        public void PasswordString(string password)
        {
            Regex rg = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$");
            if (!rg.IsMatch(password))
                throw new Exception("A senha deve ter pelo menos uma letra e um numero");
        }
    }
}