using System.ComponentModel.DataAnnotations;

namespace GmailClient.Models
{
    public class ComposeMailModel
    {
        [Required]
        [Display(Name = "To")]
        [EmailAddress]
        public string To { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}