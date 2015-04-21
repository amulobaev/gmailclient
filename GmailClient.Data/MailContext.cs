using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get { return this.GetTable<AccountEntity>(); }
        }
    }
}
