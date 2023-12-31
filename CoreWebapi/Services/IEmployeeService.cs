using CoreWebapi.Models;

namespace CoreWebapi.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int Id);
        Task<int> CreateEmployee(Employee employee);
    }
}
