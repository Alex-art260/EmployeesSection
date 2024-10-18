using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesSection.Models.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string? Surname { get; set; }

        public string? Name { get; set; }

        public string? Patronymic { get; set; }
        public string? Position { get; set; }

        [NotMapped] 
        public string? FullName => $"{Surname} {Name} {Patronymic}".Trim();

    }
}
