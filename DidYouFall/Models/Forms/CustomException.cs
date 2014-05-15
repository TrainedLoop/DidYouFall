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

            public Recaptcha(string message = "Captcha deve ser preenchido corretamente")
                : base(message)
            {
            }

            public Recaptcha(string message, Exception inner)
                : base(message, inner)
            {
            }

        }
      
    }
}