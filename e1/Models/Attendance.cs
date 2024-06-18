using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
