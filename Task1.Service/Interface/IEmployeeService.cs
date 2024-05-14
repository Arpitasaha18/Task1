using Task1.Data.Models;

namespace Task1.Service.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Department>> GetDepartments();
        Task<Employee> GetEmployeeById(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
