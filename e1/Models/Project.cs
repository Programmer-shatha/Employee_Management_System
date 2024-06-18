using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
