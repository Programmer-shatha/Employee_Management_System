using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e1.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var leaves = await _context.Leave.Include(l => l.Employee).ToListAsync();
            return View(leaves);
        }


        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Leave leave)
        {
            _context.Leave.Add(leave);
            _context.SaveChanges();
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName", leave.EmployeeId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var e = _context.Leave.SingleOrDefault(x => x.LeaveId == id);
            return View(e);
        }

        public IActionResult Update(Leave leave)
        {
            _context.Leave.Update(leave);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var l = _context.Leave.SingleOrDefault(d => d.LeaveId == id);
            if (l != null)
            {
                _context.Leave.Remove(l);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
