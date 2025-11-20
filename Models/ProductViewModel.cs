using System.ComponentModel.DataAnnotations;

namespace BasicASP.Models
{
    public class ProductViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Stock { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;
    }
}
