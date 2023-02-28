using Microsoft.AspNetCore.Mvc;
using WestcoastEducationAdministration.Models;
using WestcoastEducationAdministration.Services;

namespace WestcoastEducationAdministration.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CoursesService _service;

        public CoursesController(CoursesService service)
        {
            _service = service;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
              return View(await _service.GetAll());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.Get == null)
            {
                return NotFound();
            }

            return View(await _service.Get(id ?? 0));
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Title,Lenght,Category,Description,Details")] Course course)
        {
            if (ModelState.IsValid)
            {
                var ok = await _service.Add(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.Get == null)
            {
                return NotFound();
            }

            return View(await _service.Get(id ?? 0));
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,Title,Lenght,Category,Description,Details")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Edit(id, course);
                }
                catch (Exception e)
                {
                    throw new Exception("Something went wrong");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        //// GET: Courses/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Courses == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses
        //        .FirstOrDefaultAsync(m => m.CourseId == id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(course);
        //}

        //// POST: Courses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Courses == null)
        //    {
        //        return Problem("Entity set 'Context.Courses'  is null.");
        //    }
        //    var course = await _context.Courses.FindAsync(id);
        //    if (course != null)
        //    {
        //        _context.Courses.Remove(course);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CourseExists(int id)
        //{
        //  return _context.Courses.Any(e => e.CourseId == id);
        //}
    }
}
