using System;
using System.Data.Linq.Mapping;

namespace GmailClient.Data.Entities
{
    [Table(Name = "Users")]
    class UserEntity
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }

        [Column]
        public string User { get; set; }

        [Column]
        public string Password { get; set; }
    }
}