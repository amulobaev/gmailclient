using System;
using System.Collections.Generic;
using System.Web.Http;
using GmailClient.Model;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IMailClient _mailClient;

        /// <summary>
        /// Default constructor for API controller
        /// </summary>
        /// <param name="mailClient">Mail client implementation</param>
        public MessagesController(IMailClient mailClient)
        {
            if (mailClient == null)
                throw new ArgumentNullException("mailClient");
            _mailClient = mailClient;
        }

        [HttpGet]
        public IEnumerable<Message> Get([FromUri]string folder)
        {
            return _mailClient.GetMessages(folder);
        }
    }
}
