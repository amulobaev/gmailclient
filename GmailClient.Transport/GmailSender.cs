using System;
using System.Net;
using System.Net.Mail;
using GmailClient.Model;

namespace GmailClient.Transport
{
    /// <summary>
    /// ISender implpementation for Gmail
    /// </summary>
    public class GmailSender : IMailSender
    {
        private const string Host = "smtp.gmail.com";

        private const int Port = 587;

        private readonly IAccountInfo _accountInfo;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="accountInfo">Mail account info</param>
        public GmailSender(IAccountInfo accountInfo)
        {
            if (accountInfo == null)
                throw new ArgumentNullException("accountInfo");
            _accountInfo = accountInfo;
        }

        /// <summary>
        /// Send mail using Gmail SMTP
        /// </summary>
        /// <param name="to">Address</param>
        /// <param name="subject">Subject</param>
        /// <param name="message">Text message</param>
        public void SendMail(string to, string subject, string message)
        {
            // Create SMTP client
            using (var client = new SmtpClient(Host, Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_accountInfo.Email, _accountInfo.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            })
            {
                // Prepare mail message
                MailMessage mail = new MailMessage();
                mail.To.Add(to); // Update your email address
                mail.From = new MailAddress(_accountInfo.Email, _accountInfo.Name);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = false;

                // Send message
                client.Send(mail);
            }

        }
    }
}
