﻿using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } 
    }
}
