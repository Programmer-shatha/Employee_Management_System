using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e1.Controllers
{
    public class PerformanceReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerformanceReviewController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var reviews = await _context.PerformanceReview.Include(r => r.Employee).ToListAsync();
            return View(reviews);
        }


        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName");
            return View();
        }



        [HttpPost]
        public IActionResult Create(PerformanceReview p)
        {
            _context.PerformanceReview.Add(p);
            _context.SaveChanges();
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "FullName", p.EmployeeId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var p = _context.PerformanceReview.SingleOrDefault(x => x.PerformanceReviewId == id);
            return View(p);
        }

        public IActionResult Update(PerformanceReview p)
        {
            _context.PerformanceReview.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var p = _context.PerformanceReview.SingleOrDefault(d => d.PerformanceReviewId == id);
            if (p != null)
            {
                _context.PerformanceReview.Remove(p);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
