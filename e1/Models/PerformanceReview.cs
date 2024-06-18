using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class PerformanceReview
    {
        [Key]
        public int PerformanceReviewId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; } // Rating scale from 1 to 5
    }
}
