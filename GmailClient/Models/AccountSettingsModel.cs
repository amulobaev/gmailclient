using System.ComponentModel.DataAnnotations;

namespace GmailClient.Models
{
    public class AccountSettingsModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "New password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}