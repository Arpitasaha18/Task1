namespace Task1.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; } //000000389
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<ChangeRequestForm>? ChangeRequestForms { get; set; }
    }
}
