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
    public class ChangeRequestFormService : IChangeRequestFormService
    {
        private readonly Task1DbContext _context;

        public ChangeRequestFormService(Task1DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChangeRequestForm>> GetChangeRequestForms()
        {
            return await _context.ChangeRequestForms
                .Include(requestForm => requestForm.Employee)
                .ToListAsync();
        }

        public async Task<ChangeRequestForm> GetChangeRequestFormById(int id)
        {
            return await _context.ChangeRequestForms.FindAsync(id);
        }

        public async Task CreateChangeRequestForm(ChangeRequestForm requestForm, string signatureFilePath)
        {
            requestForm.Signature = signatureFilePath;
            _context.ChangeRequestForms.Add(requestForm);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateChangeRequestForm(ChangeRequestForm requestForm)
        {
            _context.Update(requestForm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChangeRequestForm(int id)
        {
            var requestForm = await _context.ChangeRequestForms.FindAsync(id);
            if (requestForm != null)
            {
                _context.ChangeRequestForms.Remove(requestForm);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}
