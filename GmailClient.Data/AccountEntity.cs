using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailClient.Data
{
    [Table(Name = "Accounts")]
    class AccountEntity
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Email { get; set; }

        [Column]
        public string Password { get; set; }
    }
}
