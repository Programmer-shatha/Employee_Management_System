using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<PerformanceReview> PerformanceReviews { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<Salary> Salaries { get; set; }
    }
}
