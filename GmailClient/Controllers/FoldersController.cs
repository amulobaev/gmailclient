using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GmailClient.Data;
using GmailClient.Model;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    public class FoldersController : ApiController
    {
        public IEnumerable<Folder> Get()
        {
            AccountRepository repository = new AccountRepository();
            Account account = repository.GetAll().FirstOrDefault();
            MailClient client = new MailClient(account.Email, account.Password);
            var folders = client.GetFolders();
            return folders;
        }
    }
}
