using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Models;

namespace Task1.Service.Interface
{
    public interface IDepartmentService
    {

        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task CreateDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int id);
        
    }
}
