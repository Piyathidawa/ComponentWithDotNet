using System.ComponentModel.DataAnnotations;

namespace BasicASP.Models
{
    public class PersonViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        public string PersonType { get; set; } = "Student";

        // Additional fields for different person types
        public string? StudentId { get; set; }
        public string? Company { get; set; }
        public string? JobTitle { get; set; }

        // Contract Persons list (คนที่จะทำสัญญา)
        public List<ContractPersonViewModel> ContractPersons { get; set; } = new List<ContractPersonViewModel>();
    } 
}
