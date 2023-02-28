using Microsoft.AspNetCore.Mvc;
using WestcoastEducationAdministration.Models;
using WestcoastEducationAdministration.Services;

namespace WestcoastEducationAdministration.Controllers
{
    public class TeachersController : Controller
    {
        private readonly TeachersService _service;

        public TeachersController(TeachersService service)
        {
            _service = service;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.Get == null)
            {
                return NotFound();
            }

            return View(await _service.Get(id ?? 0));
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,FirstName,LastName,Email,Phone,Address,Competence")] Teacher Teacher)
        {
            if (ModelState.IsValid)
            {
                var ok = await _service.Add(Teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(Teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.Get == null)
            {
                return NotFound();
            }

            return View(await _service.Get(id ?? 0));
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,FirstName,LastName,Email,Phone,Address,Competence")] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Edit(id, teacher);
                }
                catch (Exception e)
                {
                    throw new Exception("Something went wrong");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        //// GET: Teachers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Teachers == null)
        //    {
        //        return NotFound();
        //    }

        //    var Teacher = await _context.Teachers
        //        .FirstOrDefaultAsync(m => m.TeacherId == id);
        //    if (Teacher == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(Teacher);
        //}

        //// POST: Teachers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Teachers == null)
        //    {
        //        return Problem("Entity set 'Context.Teachers'  is null.");
        //    }
        //    var Teacher = await _context.Teachers.FindAsync(id);
        //    if (Teacher != null)
        //    {
        //        _context.Teachers.Remove(Teacher);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TeacherExists(int id)
        //{
        //  return _context.Teachers.Any(e => e.TeacherId == id);
        //}
    }
}
