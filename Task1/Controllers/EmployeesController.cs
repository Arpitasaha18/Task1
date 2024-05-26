using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Task1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Task1DbContext _context;

        public EmployeesController()
        {
            _context = new Task1DbContext();
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }


        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        public async Task<string> Create([Bind("Name, DepartmentId")][FromBody] Employee employee)
        {
            try
            {
                var employeeId = _context.Employees.Select(e => Convert.ToInt32(e.EmployeeId))
                    .Max();
                employee.EmployeeId = employeeId.ToString().PadLeft(8, '0');
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return "Successfully Created!";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]

        public async Task<string> Edit(int id, [FromBody] Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return "Employee not found.";
            }
            existingEmployee.Id = employee.Id;
            existingEmployee.Name = employee.Name; // Update the 'Name' property
            existingEmployee.DepartmentId = employee.DepartmentId; // Update the 'DepartmentId' property

            try
            {
                _context.Update(existingEmployee);
                await _context.SaveChangesAsync();
                return "Successfully updated";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        // POST: Employees/Delete/5
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return false;
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
