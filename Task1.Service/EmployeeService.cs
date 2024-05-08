using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Models;

namespace Task1.Service
{
    public class EmployeeService
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
    }
}
