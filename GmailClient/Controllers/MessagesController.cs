using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GmailClient.Data;
using GmailClient.Model;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IAccountInfo _accountInfo;

        public MessagesController(IAccountInfo accountInfo)
        {
            if (accountInfo == null)
                throw new ArgumentNullException("accountInfo");
            _accountInfo = accountInfo;
        }

        [HttpGet]
        public IEnumerable<Message> Get([FromUri]string folder)
        {
            AccountRepository repository = new AccountRepository();
            Account account = repository.GetAll().FirstOrDefault();
            MailClient client = new MailClient(_accountInfo);
            var messages = client.GetMessages(folder);
            return messages;
        }
    }
}
