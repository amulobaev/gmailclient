using System;
using System.Collections.Generic;
using System.Web.Http;
using GmailClient.Model;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    /// <summary>
    /// API controller for fetching imap folders
    /// </summary>
    public class FoldersController : ApiController
    {
        private readonly IMailClient _mailClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mailClient">Mail client implementation</param>
        public FoldersController(IMailClient mailClient)
        {
            if (mailClient == null)
                throw new ArgumentNullException("mailClient");
            _mailClient = mailClient;
        }

        /// <summary>
        /// Get list of all folders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Folder> Get()
        {
            return _mailClient.GetFolders();
        }

    }
}