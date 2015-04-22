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
        [HttpGet]
        public IEnumerable<Message> Get([FromUri]string folder)
        {
            AccountRepository repository = new AccountRepository();
            Account account = repository.GetAll().FirstOrDefault();
            MailClient client = new MailClient(account.Email, account.Password);
            var messages = client.GetMessages(folder);
            return messages;
        }
    }
}
