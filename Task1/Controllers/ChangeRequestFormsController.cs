using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task1.Data.Enums;
using Task1.Data.Models;
using Task1.Data.ViewModels;

namespace Task1.Controllers
{
    public class ChangeRequestFormsController : Controller
    {
        private readonly Task1DbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _signFolderName = "signature";

        public ChangeRequestFormsController(IWebHostEnvironment env)
        {
            _env = env;
            _context = new Task1DbContext();
        }

        // GET: ChangeRequestForms 
        public async Task<IActionResult> Index()
        {
            return View();
        }
        //join 2 tables. ChangeRequestFormVM,ChangeRequestForms
        public async Task<IEnumerable<ChangeRequestFormVM>> GetChangeRequestForms()
        {
            return await _context.ChangeRequestForms
                .Select(e => new ChangeRequestFormVM
                {
                    Id = e.Id,
                    ProjectName = e.ProjectName,
                    ModuleName = e.ModuleName,
                    RequestByName = e.RequestBy.Name,
                    RequestByDeptName = e.RequestBy.Department.Name,
                    RequestDate = e.RequestDate.ToString("dd/MM/yyyy"),
                    ChangeRequestDetails = e.ChangeRequestDetails,
                    Status = e.Status,
                    Signature = e.Signature,
                    EmployeeName = e.ReviewBy.Name,
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }



        // GET:ChangeRequestForms /Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestForm = await _context.ChangeRequestForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestForm == null)
            {
                return NotFound();
            }

            return View(requestForm);
        }



        // POST: ChangeRequestForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<string> Create([FromBody] ChangeRequestForm requestForm, IFormFile signature)
        {
            if (!ModelState.IsValid)
            {
                var err = ModelState.ErrorCount;
            }
            try
            {

                //if (signature == null)
                //{
                //    return "no picture foud";
                //}

                //var filePath = Path.Combine(_env.WebRootPath, _signFolderName, signature.FileName);
                //using (var stream = System.IO.File.Create(filePath))
                //{
                //    await signature.CopyToAsync(stream);
                //}

                //requestForm.Signature = Path.Combine(_signFolderName, signature.FileName);

                requestForm.ReviewById = 44; //take Userid from logged in session

                _context.Add(requestForm);
                await _context.SaveChangesAsync();
                return "successfully updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
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

        // POST: ChangeRequestForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> Edit(int id, [FromBody] ChangeRequestForm requestForm)
        {
            var existingUser = await _context.ChangeRequestForms.FindAsync(id);
            if (existingUser == null)
            {
                return "User not found.";
            }

            existingUser.ProjectName = requestForm.ProjectName;
            existingUser.ModuleName = requestForm.ModuleName;
            existingUser.RequestById = requestForm.RequestById;
            existingUser.RequestDate = requestForm.RequestDate;
            existingUser.ChangeRequestDetails = requestForm.ChangeRequestDetails;
            existingUser.Status = requestForm.Status;
            existingUser.Signature = requestForm.Signature;


            try
            {
                _context.Update(existingUser);
                await _context.SaveChangesAsync();
                return "Successfully updated";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }




        // POST: ChangeRequestForm/Delete/5
        //[HttpPost, ActionName("Delete")]

        public async Task<bool> Delete(int id)
        {
            try
            {
                var changeRequestForm = await _context.ChangeRequestForms.FindAsync(id);
                if (changeRequestForm == null)
                {
                    return false;
                }

                _context.ChangeRequestForms.Remove(changeRequestForm);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ChangeRequestFormExists(int id)
        {
            return _context.ChangeRequestForms.Any(e => e.Id == id);
        }
    }
}
