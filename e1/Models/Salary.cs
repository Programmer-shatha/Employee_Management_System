using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
