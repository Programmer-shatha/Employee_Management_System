using e1.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace e1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Salary> Salary { get; set; }

        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<PerformanceReview> PerformanceReview { get; set; }

        public DbSet<Project> Project { get; set; }
    }
}
