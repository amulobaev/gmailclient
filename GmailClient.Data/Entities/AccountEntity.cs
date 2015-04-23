using System;
using System.Data.Linq.Mapping;

namespace GmailClient.Data.Entities
{
    /// <summary>
    /// Account (mail account) entity
    /// </summary>
    [Table(Name = "Accounts")]
    class AccountEntity
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Column]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Column]
        public string Password { get; set; }
    }
}
