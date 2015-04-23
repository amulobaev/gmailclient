using System.Configuration;
using System.Data.Linq;
using GmailClient.Data.Entities;

namespace GmailClient.Data
{
    /// <summary>
    /// Database context usinq LINQ to SQL
    /// </summary>
    internal class MailContext : DataContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MailContext()
            : base(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
        {
        }

        /// <summary>
        /// Accounts table (mail accounts)
        /// </summary>
        public Table<AccountEntity> Accounts
        {
            get { return GetTable<AccountEntity>(); }
        }

        /// <summary>
        /// Users table (local users_
        /// </summary>
        public Table<UserEntity> Users
        {
            get { return GetTable<UserEntity>(); }
        }

    }
}