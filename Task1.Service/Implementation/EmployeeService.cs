using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Models;
using Task1.Service.Interface;

namespace Task1.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Task1DbContext _context;


        public EmployeeService()
        {
            _context = new Task1DbContext();
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees
                .Include(emp => emp.Department)
                .ToListAsync();
        }


        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }


        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees
                .Include(emp => emp.Department)
                .Where(emp => emp.Id == id)
                .FirstOrDefaultAsync();
        }


        public async Task CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }


        
    }
}
