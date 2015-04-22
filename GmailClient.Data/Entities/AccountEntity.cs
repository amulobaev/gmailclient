using System;
using System.Data.Linq.Mapping;

namespace GmailClient.Data.Entities
{
    [Table(Name = "Accounts")]
    class AccountEntity
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Email { get; set; }

        [Column]
        public string Password { get; set; }
    }
}
