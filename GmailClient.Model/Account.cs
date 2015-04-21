using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailClient.Model
{
    /// <summary>
    /// Gmail account info
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        
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
