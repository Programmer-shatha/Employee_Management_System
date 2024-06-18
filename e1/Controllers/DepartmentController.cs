using e1.Data;
using e1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Department.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department Department)
        {
            _context.Department.Add(Department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var e = _context.Department.SingleOrDefault(x => x.DepartmentId == id);
            return View(e);
        }

        public IActionResult Update(Department department)
        {
            _context.Department.Update(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var depart = _context.Department.SingleOrDefault(d => d.DepartmentId == id);
            if (depart != null)
            {
                _context.Department.Remove(depart);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



    }

}
