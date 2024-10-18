using AutoMapper;
using EmployeesSection.Models;
using EmployeesSection.Models.Dto;

namespace EmployeesSection.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        { 
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
