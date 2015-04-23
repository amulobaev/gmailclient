using System;

namespace GmailClient.Model
{
    /// <summary>
    /// Message (IMAP)
    /// </summary>
    public class Message
    {
        public long UId { get; set; }
        public string FromAddress { get; set; }
        public string FromDisplayName { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }
    }
}
