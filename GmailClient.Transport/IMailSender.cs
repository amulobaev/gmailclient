namespace GmailClient.Transport
{
    /// <summary>
    /// Sender interface
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="to">Address</param>
        /// <param name="subject">Subject</param>
        /// <param name="message">Message</param>
        void SendMail(string to, string subject, string message);
    }
}