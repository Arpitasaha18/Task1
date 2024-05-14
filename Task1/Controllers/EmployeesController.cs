using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task1.Data.Models;
using Task1.Service;
using Task1.Service.Interface;

namespace Task1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService employeeService)
        {
            _service = employeeService;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _service.GetEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _service.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            var departments = await _service.GetDepartments(); 
            ViewData["Departments"] = new SelectList(departments, "Id", "Name");

            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }

            // Reload departments if validation fails
            var departments = await _service.GetDepartments();
            ViewData["Departments"] = new SelectList(departments, "Id", "Name");

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _service.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            var departments = await _service.GetDepartments();
            ViewData["Departments"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);

            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }

            var departments = await _service.GetDepartments(); // Reload if validation fails
            ViewData["Departments"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);

            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _service.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
