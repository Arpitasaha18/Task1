using System.ComponentModel.DataAnnotations;

namespace Task1.Data.Models
{
    public class Department
    {
        
        public int Id { get; set; }
        
     
        //public int DId { get; set; }

        public string Name { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
