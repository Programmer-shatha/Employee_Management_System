using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.Include(e => e.Department).ToListAsync();
            return View(employees);
        }


        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var e = _context.Employee.SingleOrDefault(x => x.EmployeeId == id);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", e.DepartmentId);
            return View(e);
        }

        public IActionResult Update(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var e = _context.Employee.SingleOrDefault(d => d.EmployeeId == id);
            if (e != null)
            {
                _context.Employee.Remove(e);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

