using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e1.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var attendances = await _context.Attendance.Include(a => a.Employee).ToListAsync();
            return View(attendances);
        }

        public IActionResult CheckIn()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult CheckIn(Attendance attendance)
        {
            _context.Attendance.Add(attendance);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var a = _context.Attendance.SingleOrDefault(x => x.AttendanceId == id);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName", a.EmployeeId);
            return View(a);
        }

        public IActionResult Update(Attendance attendance)
        {
            _context.Attendance.Update(attendance);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var a = _context.Attendance.SingleOrDefault(d => d.AttendanceId == id);
            if (a != null)
            {
                _context.Attendance.Remove(a);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
