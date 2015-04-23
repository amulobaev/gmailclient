using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using GmailClient.Model;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    /// <summary>
    /// API controller for manipulating messages
    /// </summary>
    [Authorize]
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

        /// <summary>
        /// Get all messages in folder
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Message> Get([FromUri]string folder)
        {
            return _mailClient.GetMessages(folder);
        }

        public void Delete(int id)
        {
            _mailClient.DeleteMessage(id);
        }

    }
}