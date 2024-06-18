using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace e1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var project = _context.Project
                .Include(p => p.EmployeeProjects)
                .Select(p => new {
                    Name = p.Name,
                    EmployeeCount = p.EmployeeProjects.Count
                })
                .ToList();

            
            ViewBag.Projects = project;
            ViewBag.EmployeeCount = _context.Employee.Count();
            ViewBag.DepartmentCount = _context.Department.Count();
            ViewBag.ProjectCount = project.Count;

            return View();
        }



      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
