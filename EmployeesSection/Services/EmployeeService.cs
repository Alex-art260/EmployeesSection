using AutoMapper;
using EmployeesSection.Data;
using EmployeesSection.Interfaces;
using EmployeesSection.Models;
using EmployeesSection.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(EmployeeDto dto)
        {
            var item = _mapper.Map<Employee>(dto);

            if (dto.FullName != null && IsFullNameUnique(dto.FullName))
            {
                _dbContext.Employees.Add(item);
                await _dbContext.SaveChangesAsync();
                return item.Id;
            }
            else
            {
                throw new Exception("Сотрудник с таким ФИО уже существует");
            }
        }

        public async Task<int> Delete(int id)
        {
            var item = await _dbContext.Employees.FindAsync(id);

            if (item == null)
                throw new Exception($"Запись не найдена.");

            _dbContext.Employees.Remove(item);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var items = await _dbContext.Employees.ToListAsync();

            if (items != null || items.Count() != 0)
            {
                var mappedItems = _mapper.Map<List<EmployeeDto>>(items);

                return mappedItems;
            }
            return null;
        }

        public async Task<int> UpdateEmployee(EmployeeDto dto)
        {
            if (dto.FullName != null && IsFullNameUnique(dto.FullName))
            {
                var item = await _dbContext.Employees.FindAsync(dto.Id);

                if (item == null)
                    throw new Exception($"Запись не найдена.");

                _mapper.Map(dto, item);

                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Сотрудник с таким ФИО уже существует");
            }
        }

        public bool IsFullNameUnique(string fullName)
        {
            if (_dbContext.Employees.Count() > 0)
            {
                var parts = fullName.Split(' ');
                if(_dbContext.Employees.Any(e => e.Surname == parts[0] && e.Name == parts[1]
                    && e.Patronymic == parts[2]))
                return false;
            }

            return true; 
        }
    }
}
