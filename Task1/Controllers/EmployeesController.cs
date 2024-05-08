using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task1.Data.Models;
using Task1.Service;

namespace Task1.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly Task1DbContext _context;
        private readonly EmployeeService _service;
        public EmployeesController()
        {
            //_context = new Task1DbContext();
            _service = new EmployeeService();
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _service.GetEmployees();
            return View(employees);
        }

        //// GET: Employees/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        //.Include(e => e.Department)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        //// GET: Employees/Create
        //public IActionResult Create()
        //{

        //    var data = _context.Departments.ToList();
        //    ViewData["Departments"] = data;
        //    //ViewData["DId"] = new SelectList(_context.Departments, "DId", "DId");
        //    return View();
        //}

        //// POST: Employees/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create(Employee employee)
        //{
        //    //if (ModelState.IsValid)
        //    try
        //    {
        //        //var emp = new Employee();
        //        employee.Name = employee.Name;
        //        employee.EmployeeId = employee.EmployeeId;
        //        //employee.Id = employee.Id;

        //        _context.Employees.Add(employee);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception exp)
        //    {
        //        //ViewData["DId"] = new SelectList(_context.Departments, "Id", "Id", employee.DId);
        //        var data = _context.Departments;
        //        ViewData["Departments"] = data.ToList();
        //        ViewData["Error"] = exp.Message;
        //        return View(employee);
        //    }
        //}

        ////-------------------------------------------

       

        //// GET: Employees/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["DId"] = new SelectList(_context.Departments, "DId", "DId", employee.Id);
        //    return View(employee);
        //}

        //// POST: Employees/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Deparment.DId")] Employee employee)
        //{
        //    if (id != employee.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(employee);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeeExists(employee.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["DId"] = new SelectList(_context.Departments, "DId", "DId", employee.DId);
        //    return View(employee);
        //}

        //// GET: Employees/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .Include(e => e.Department)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee != null)
        //    {
        //        _context.Employees.Remove(employee);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.Id == id);
        //}
    }
}
