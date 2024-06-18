using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e1.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalaryController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var salaries = await _context.Salary.Include(s => s.Employee).ToListAsync();
            return View(salaries);
        }


        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName");
            return View();
        }

   
        [HttpPost]
        public IActionResult Create(Salary salary)
        {
            _context.Salary.Add(salary);
            _context.SaveChanges();
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName", salary.EmployeeId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var s = _context.Salary.SingleOrDefault(x => x.SalaryId == id);
            return View(s);
        }

        public IActionResult Update(Leave leave)
        {
            _context.Leave.Update(leave);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var s = _context.Salary.SingleOrDefault(d => d.SalaryId == id);
            if (s != null)
            {
                _context.Salary.Remove(s);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}


