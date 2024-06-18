using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e1.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Project project)
        {
            _context.Project.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var e = _context.Project.SingleOrDefault(x => x.ProjectId == id);
            return View(e);
        }

        public IActionResult Update(Project project)
        {
            _context.Project.Update(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var p = _context.Project.SingleOrDefault(d => d.ProjectId == id);
            if (p != null)
            {
                _context.Project.Remove(p);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        public IActionResult AssignEmployees(int projectId)
        {
            ViewData["ProjectId"] = projectId;
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName");
            return View();
        }


        [HttpPost]
        public IActionResult AssignEmployees(EmployeeProject employeeProject)
        {

            _context.EmployeeProject.Add(employeeProject);
            _context.SaveChanges();
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName", employeeProject.EmployeeId);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            var project = await _context.Project
                .Include(p => p.EmployeeProjects)
                .ThenInclude(ep => ep.Employee)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }

}
