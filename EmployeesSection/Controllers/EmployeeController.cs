using EmployeesSection.Interfaces;
using EmployeesSection.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesSection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        [HttpPost("[action]")]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto data)
        {

            var result = await _employeeService.Create(data);
            return Ok(result);
        }


        /// <summary>
        /// Возвращает список сотрудников
        /// </summary>
        [HttpGet("[action]")]
        public async Task<ActionResult> GetEmployees()
        {
            var result = await _employeeService.GetEmployees();
            return Ok(result);
        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult> Update(EmployeeDto dto)
        {
            var result = await _employeeService.UpdateEmployee(dto);
            return Ok(result);
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _employeeService.Delete(id);
            return Ok(result);
        }
    }
}
