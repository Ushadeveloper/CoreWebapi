using CoreWebapi.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CoreWebapi.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<List<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employee;";

            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }
        public async Task<Employee> GetEmployee(int id)
        {
            var query = $"SELECT * FROM Employee where Id ={id}";

            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.FirstOrDefault();
            }
        }
        public async Task<int> CreateEmployee(Employee employee)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var query = $"insert into Employee ( EmployeeName, CNIC, Address, PhoneNo ) values " +
                                  $"('{employee.EmployeeName}','{employee.CNIC}','{employee.Address}','{employee.PhoneNo}');";
                var result = await connection.ExecuteAsync(query);
                return result;
            }
        }
        public async Task<int> UpdateEmployee(Employee employee)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                 var query = $"update Employee set EmployeeName= '{employee.EmployeeName}', CNIC= '{employee.CNIC}', Address= '{employee.Address}', PhoneNo ={employee.PhoneNo}  " +
                                   $"where Id ={employee.Id}";
               var result = await connection.ExecuteAsync(query);
                return result;
            }
        }
        public async Task<int> DeleteEmployee(int Id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var query = $"Delete from Employee  " +
                                  $"where Id ={Id}";
                var result = await connection.ExecuteAsync(query);
                return result;
            }
        }
    }
}
