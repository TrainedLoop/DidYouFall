using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DidYouFall.ToolBox
{
    public class Email
    {
        public static Email OfflineEmail(Server server)
        {
            string subject = "Server: " + server.Name + " IP: " + server.Host + " Está Offline";
            string body = "Verificamos que o status do servidor " + server.Name + " IP: " + server.Host + " foi alterado para Offline";
            return new Email(subject, body, server.Contactemail);
        }
        public static Email OnlineEmail(Server server)
        {
            string subject = "Server: " + server.Name + " IP: " + server.Host + " Está Online";
            string body = "Verificamos que o status do servidor " + server.Name + " IP: " + server.Host + " foi alterado para Online";
            return new Email(subject, body, server.Contactemail);
        }

#warning senhasDeEmail
        private string SMTP = "CONFIGURAR";
        private string SendMail = "CONFIGURAR";
        private string PassWord = "CONFIGURAR";

        private string _Subject;
        private string Subject
        {
            get { return this._Subject; }
            set
            {
                if (value.Trim().Length < 3)
                    throw new Exception("Escreva um assunto com mais de 3 caracteres");
                if (value.Length > 30)
                    throw new Exception("Assunto com no maximo 30 caracteres");
                this._Subject = value;
            }
        }
        private string _Message;
        private string Message
        {
            get { return this._Message; }
            set
            {
                if (value.Trim().Length < 10)
                    throw new Exception("A mensagem precisa ter mais de 10 caracteres");
                if (value.Length > 600)
                    throw new Exception("A mensagem com no maximo 600 caracteres");
                this._Message = value;
            }
        }
        public string EmailtoReceive { get; set; }




        private Email(string subject, string message, string emailtoReceive)
        {
            Subject = subject;
            Message = message;
            EmailtoReceive = emailtoReceive;
        }

        public Email(Email email)
        {
            Subject = email.Subject;
            Message = email.Message;
        }
        public void sendMail()
        {
            try
            {
                MailMessage mail = new MailMessage(SendMail, EmailtoReceive);
                SmtpClient client = new SmtpClient();
                client.Port = 80;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(SendMail, PassWord);
                client.Host = SMTP;
                mail.Subject = Subject + "/n/n";
                mail.Body = Message;
                client.Send(mail);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }


}