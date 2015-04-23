using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailClient.Model;

namespace GmailClient.Data
{
    /// <summary>
    /// IAccountInfo implementation
    /// </summary>
    public class AccountInfo : IAccountInfo
    {
        private readonly string _name;
        private readonly string _email;
        private readonly string _password;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Repository implementation</param>
        public AccountInfo(IRepository<Account> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            Account account = repository.GetAll().FirstOrDefault();
            if (account != null)
            {
                _name = account.Name;
                _email = account.Email;
                _password = account.Password;
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
