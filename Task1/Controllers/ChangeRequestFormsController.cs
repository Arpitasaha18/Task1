using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

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
            return View(await _context.ChangeRequestForms.ToListAsync());
        }

        // GET:ChangeRequestForms /Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestForm = await _context.ChangeRequestForms
                .FirstOrDefaultAsync(m => m.id == id);
            if (requestForm == null)
            {
                return NotFound();
            }

            return View(requestForm);
        }

        // GET: ChangeRequestForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChangeRequestForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChangeRequestForm requestForm, IFormFile signature)
        {
            //if (ModelState.IsValid)
            {
                if(signature == null)
                {
                    return BadRequest();
                }

                var filePath = Path.Combine(_env.WebRootPath, _signFolderName, signature.FileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await signature.CopyToAsync(stream);
                }

                requestForm.signature = Path.Combine(_signFolderName, signature.FileName);

                _context.Add(requestForm);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(requestForm);
        }

        // GET: ChangeRequestForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestForm = await _context.ChangeRequestForms.FindAsync(id);
            if (requestForm == null)
            {
                return NotFound();
            }
            return View(requestForm);
        }

        // POST: ChangeRequestForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,projectName,moduleName,requestBy,requestDate,changeRequestDetails,status,sugnature")] ChangeRequestForm requestForm)
        {
            if (id != requestForm.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeRequestFormExists(requestForm.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(requestForm);
        }

        // GET: ChangeRequestForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestForm = await _context.ChangeRequestForms
                .FirstOrDefaultAsync(m => m.id == id);
            if (requestForm == null)
            {
                return NotFound();
            }

            return View(requestForm);
        }

        // POST: ChangeRequestForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.ChangeRequestForms.FindAsync(id);
            if (user != null)
            {
                _context.ChangeRequestForms.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangeRequestFormExists(int id)
        {
            return _context.ChangeRequestForms.Any(e => e.id == id);
        }
    }
}
