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
    public class InboxController : ApiController
    {
        private readonly EmailsRepository _repository;

        public InboxController()
        {
            _repository = new EmailsRepository();
        }

        public IEnumerable<Email> GetAll()
        {
            return _repository.GetAll();
        }

    }
}