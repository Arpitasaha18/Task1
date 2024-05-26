using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data.Models;

namespace Task1.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly Task1DbContext _context;

        public DepartmentsController()
        {
            _context = new Task1DbContext();
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        public async Task<string> Create([Bind("Name")][FromBody] Department department)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return "Successfully Created!";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
            //}
            //return "Model is not validate!";
        }


        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> Edit(int id, [FromBody] Department department)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null)
            {
                return "Department not found.";
            }

            existingDepartment.Name = department.Name; // Update only the 'Name' property

            try
            {
                _context.Update(existingDepartment);
                await _context.SaveChangesAsync();
                return "Successfully updated";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }



        // POST: Departments/Delete/5
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            try
            {
                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    return false;
                }

                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}