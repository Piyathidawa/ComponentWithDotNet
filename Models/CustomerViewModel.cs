using System.ComponentModel.DataAnnotations;

namespace BasicASP.Models
{
    public class CustomerViewModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        // Nested address
        public AddressViewModel Address { get; set; } = new AddressViewModel();
    }
}
