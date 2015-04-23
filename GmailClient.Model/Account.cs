using System;
using System.ComponentModel.DataAnnotations;

namespace GmailClient.Model
{
    /// <summary>
    /// Gmail account info
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
