namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string?  Picture { get; set; }

        public int Email { get; set; }

        public string? Name { get; set; }
        public string? Address { get; set; }
        
        public string? PhoneNumber { get; set; }

        public string? Department { get; set; }
    }
}
