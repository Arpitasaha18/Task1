using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Enums;
using Task1.Data.Models;

namespace Task1.Data.ViewModels
{
    public class ChangeRequestFormVM
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ModuleName { get; set; }
        public string? RequestByName { get; set; }
        public string? RequestByDeptName { get; set; }
        public string RequestDate { get; set; }
        public string ChangeRequestDetails { get; set; }
        public string Status { get; set; }
        public string Signature { get; set; }
        public string EmployeeName { get; set; }
    }
}
