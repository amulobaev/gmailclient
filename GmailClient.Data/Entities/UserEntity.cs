using System;
using System.Data.Linq.Mapping;

namespace GmailClient.Data.Entities
{
    /// <summary>
    /// Local user entity
    /// </summary>
    [Table(Name = "Users")]
    class UserEntity
    {
        /// <summary>
        /// Idenifier
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [Column]
        public string User { get; set; }

        /// <summary>
        /// Password (hash)
        /// </summary>
        [Column]
        public string Password { get; set; }
    }
}