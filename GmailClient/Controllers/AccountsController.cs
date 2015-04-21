using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GmailClient.Data;
using GmailClient.Model;

namespace GmailClient.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly AccountRepository _repository = new AccountRepository();

        public Account Get(int id)
        {
            Account account = _repository.Get(id);
            return account;
        }
    }
}
