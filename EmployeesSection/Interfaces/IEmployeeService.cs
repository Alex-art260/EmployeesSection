using EmployeesSection.Models.Dto;

namespace EmployeesSection.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> Create(EmployeeDto dto);
        Task<List<EmployeeDto>> GetEmployees();
        Task<int> Delete(int id);
        Task<int> UpdateEmployee(EmployeeDto dto);
        bool IsFullNameUnique(string fullName);
    }
}
