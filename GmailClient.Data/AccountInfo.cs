using System;
using System.Linq;
using GmailClient.Model;

namespace GmailClient.Data
{
    /// <summary>
    /// IAccountInfo implementation (get account info from database)
    /// </summary>
    public class AccountInfo : IAccountInfo
    {
        #region Fields

        private readonly string _name;
        private readonly string _email;
        private readonly string _password;

        #endregion Fields

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

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return _email; }
        }

        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return _password; }
        }
    }
}