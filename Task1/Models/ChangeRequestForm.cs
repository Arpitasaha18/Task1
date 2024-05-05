using Task1.Enums;

namespace Task1.Models
{
    public class ChangeRequestForm
    {
        public int id { get; set; }
        public string projectName { get; set; }
        public string moduleName { get; set; }
        public string requestBy { get; set; }
        public DateTime requestDate { get; set; }
        public string changeRequestDetails { get; set; }
        public Status status { get; set; }
        public string signature { get; set; }
    }
}
