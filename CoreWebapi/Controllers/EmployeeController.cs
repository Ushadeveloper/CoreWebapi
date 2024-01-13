using CoreWebapi.Models;
using CoreWebapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebapi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("api/Employee")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                if (employees.Count == 0)
                {
                    return NotFound("Employees not exist");
                }


                return this.Ok(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
        [HttpGet("api/Employee/{id}")]
        public async Task<IActionResult> GetEmployees(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound($"Employee{id} not exist");
            }


            return this.Ok(employee);
        }
        [HttpPost("api/Employee")]
        public async Task<IActionResult> CreateEmployee( [FromBody] Employee employee)
        {
            try
            {
                int result = await _employeeService.CreateEmployee(employee);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }

        [HttpPut("api/Employee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                var dbEmployee = await _employeeService.GetEmployee(id);
                if (dbEmployee == null)
                {
                    return this.NotFound($"EmployeeId {id} not found..");
                }
                // employee.Id=dbEmployee.Id;
                employee.Id = id;
                int result = await _employeeService.UpdateEmployee(employee);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }
        [HttpDelete("api/Employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var dbEmployee = await _employeeService.GetEmployee(id);
                if (dbEmployee == null)
                {
                    return this.NotFound($"EmployeeId {id} not found..");
                }
                int result = await _employeeService.DeleteEmployee(id);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");

            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }
    }
}
