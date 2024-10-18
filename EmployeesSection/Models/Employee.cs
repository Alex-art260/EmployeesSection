using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesSection.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Patronymic { get; set; }
        public string? Position { get; set; }

        [NotMapped]
        public string? FullName => $"{Surname} {Name} {Patronymic}".Trim();
    }
}
