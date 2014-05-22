using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class CustomException
    {
        public class Recaptcha : Exception
        {

            public Recaptcha(string message = "Captcha deve ser preenchido ")
                : base(message)
            {
            }

        }
        public class EmptyRecaptcha : Exception
        {

            public EmptyRecaptcha(string message = "Captcha deve ser preenchido")
                : base(message)
            {
            }

        }

        public class ErrorOnRegister : Exception
        {

            public ErrorOnRegister(string message = "Erro no Registro")
                : base(message)
            {
            }



        }

    }
}