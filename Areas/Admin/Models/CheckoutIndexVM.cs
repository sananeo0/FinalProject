using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.Models
{
    public class CheckoutIndexVM
    {
        [Required]
        public List<string> FirstName { get; set; }
        [Required]
        public List<string> LastName { get; set; }
        [Required]
        public List<string> CompanyName { get; set; }
        [Required]
        public List<string> Email { get; set; }
        [Required]
        public List<string> Country { get; set; }
        [Required]
        public List<string> Address { get; set; }
        [Required]
        public List<string> Town { get; set; }
        [Required]
        public List<string> ZipCode { get; set; }
        [Required]
        public List<string> PhoneNumber { get; set; }
        [Required]
        public List<string> Comment { get; set; }
    }
}
