using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class SubscriptionSubscribeVM
    {
        [Required]
        public string Email { get; set; }
    }
}
