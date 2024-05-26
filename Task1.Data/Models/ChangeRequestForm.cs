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
        public int RequestById { get; set; }
        public Employee RequestBy { get; set; }
        public DateTime RequestDate { get; set; }
        public string ChangeRequestDetails { get; set; }
        public string Status { get; set; }
        public string Signature { get; set; }

        public int ReviewById { get; set; }
        public Employee ReviewBy { get; set; }
    }
}
