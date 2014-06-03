using DidYouFall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace DidYouFall.ToolBox
{
    public class Email
    {
        public static Email OfflineEmail(Server server)
        {
            string subject = "Server: " + server.Name + " IP: " + server.IP + " Está Offline";
            string body = "Verificamos que o status do servidor " + server.Name + " IP: " + server.IP + " foi alterado para Offline";
            return new Email(subject, body, server.Contactemail);
        }
        public static Email OnlineEmail(Server server)
        {
            string subject = "Server: " + server.Name + " IP: " + server.IP + " Está Online";
            string body = "Verificamos que o status do servidor " + server.Name + " IP: " + server.IP + " foi alterado para Online";
            return new Email(subject, body, server.Contactemail);
        }

#warning senhasDeEmail
        private string SMTP = "Configurar";
        private string SendMail = "Configurar";
        private string PassWord = "Configurar";
        private int Port = 25;//Configurar

        public string Subject { get; set; }
        public string Message { get; set; }

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
            EmailtoReceive = email.EmailtoReceive;
        }
        public async void sendMail()
        {
            try
            {
                MailMessage mail = new MailMessage(SendMail, EmailtoReceive);
                SmtpClient client = new SmtpClient();
                SmtpClient smtp = new SmtpClient(SMTP, Port);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(SendMail, PassWord);
                //smtp.EnableSsl = true;
                mail.Subject = Subject;
                mail.Body = Message;

                Object state = mail;
                //smtp.SendCompleted += new SendCompletedEventHandler(MailDeliveryComplete);
                smtp.Send(mail);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }


}