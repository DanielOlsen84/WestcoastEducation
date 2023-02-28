using Microsoft.AspNetCore.Mvc;
using WestcoastEducationStudentPortal.Services;

namespace WestcoastEducationStudentPortal.Controllers
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
    }
}
