using System.ComponentModel.DataAnnotations;

namespace GmailClient.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User")]
        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}