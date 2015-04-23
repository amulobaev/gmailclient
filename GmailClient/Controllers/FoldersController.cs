using System;
using System.Collections.Generic;
using System.Web.Http;
using GmailClient.Model;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    public class FoldersController : ApiController
    {
        private readonly IAccountInfo _accountInfo;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountInfo">IAccountInfo implementation</param>
        public FoldersController(IAccountInfo accountInfo)
        {
            if (accountInfo == null)
                throw new ArgumentNullException("accountInfo");
            _accountInfo = accountInfo;
        }

        public IEnumerable<Folder> Get()
        {
            MailClient client = new MailClient(_accountInfo);
            var folders = client.GetFolders();
            return folders;
        }
    }
}
