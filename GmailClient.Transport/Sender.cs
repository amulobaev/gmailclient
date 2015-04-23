using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GmailClient.Transport
{
    public class Sender
    {
        public Sender()
        {
        }

        public void SendMail(string to, string subject, string message)
        {
            //Update your SMTP server credentials
            using (var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("mulobaev.a@gmail.com", "691ee1da6c"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            })
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to); // Update your email address
                mail.From = new MailAddress("mulobaev.a@gmail.com");
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = false;
                client.Send(mail);
            }
            
        }
    }
}
