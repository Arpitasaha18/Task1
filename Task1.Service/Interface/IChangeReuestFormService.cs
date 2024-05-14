using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Models;

namespace Task1.Service.Interface
{
    public interface IChangeRequestFormService
    {
        Task<IEnumerable<ChangeRequestForm>> GetChangeRequestForms();
        Task<ChangeRequestForm> GetChangeRequestFormById(int id);
        Task CreateChangeRequestForm(ChangeRequestForm requestForm, string signatureFilePath);
        Task UpdateChangeRequestForm(ChangeRequestForm requestForm);
        Task DeleteChangeRequestForm(int id);
        
    }
}

