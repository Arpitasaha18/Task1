using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Task1.Data.Enums;

namespace Task1.Data.Models
{
    public class ChangeRequestForm
    {
        public int Id { get; set; }
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        public string ModuleName { get; set; }
        public string? RequestBy { get; set; }
        public DateTime RequestDate { get; set; }
        public string ChangeRequestDetails { get; set; }
        public Status Status { get; set; }
        public string Signature { get; set; }

        public int? EmpId { get; set; }
        public Employee Employee { get; set; }
    }
}
