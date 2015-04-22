using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailClient.Data.Entities;

namespace GmailClient.Data
{
    /// <summary>
    /// Database context usinq LINQ to SQL
    /// </summary>
    internal class MailContext : DataContext
    {
        static MailContext()
        {
            // Mappings
        }

        public MailContext()
            : base(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
        {
        }

        public Table<AccountEntity> Accounts
        {
            get { return GetTable<AccountEntity>(); }
        }

        public Table<UserEntity> Users
        {
            get { return GetTable<UserEntity>(); }
        }

    }
}