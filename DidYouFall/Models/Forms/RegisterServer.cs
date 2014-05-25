﻿using DidYouFall.Repository;
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
        public bool Success { get; set; }
        public RegisterServer()
        {
            Server = new Server();
            Success = false;
        }

        public void Setup(string name, string host, string contactemail, Times verificationtime, User loggedUser)
        {
            try
            {
                Validations.Inputs vldInpt = new Validations.Inputs();
                Validations.DataBase vldDb = new Validations.DataBase();
                vldInpt.IPString(host);
                vldInpt.EmailString(contactemail);
                vldDb.RegisteredHostOnUser(host, loggedUser);
                Server = new Server { Name = name, Host = host, Emailsent = false, CheckTime = verificationtime, Contactemail = contactemail, User = loggedUser };

            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Success = false;
                Server = new Server { Name = name, Emailsent = false, CheckTime = verificationtime, Contactemail = contactemail };
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
                    Server = new Repository.Server();
                    Success = true;
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