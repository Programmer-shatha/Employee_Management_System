using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string Role { get; set; }
    }
}
