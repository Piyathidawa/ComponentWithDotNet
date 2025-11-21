using System.ComponentModel.DataAnnotations;

namespace BasicASP.Models
{
    public class ContractPersonViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [StringLength(200)]
        public string? Position { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
    }
}
