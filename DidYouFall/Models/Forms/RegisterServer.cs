using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms
{
    public class RegisterServer
    {
        public Server Server { get; protected set; }
        public string Error { get; set; }
        public RegisterServer()
        {
            Server = new Server();
        }

        public void Setup(string host, string contactemail, int verificationtime)
        {
            try
            {
                Validations.Inputs vldInpt = new Validations.Inputs();
                Validations.DataBase vldDb = new Validations.DataBase();
                vldInpt.IPString(host);
                vldInpt.EmailString(contactemail);
                Server = new Server { Host = host, Emailsent = false, Verificationtime = verificationtime, Contactemail = contactemail };

            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Server = new Server { Host = host, Emailsent = false, Verificationtime = verificationtime, Contactemail = contactemail };
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
                    session.Save(Server);
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