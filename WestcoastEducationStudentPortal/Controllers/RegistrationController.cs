using Microsoft.AspNetCore.Mvc;
using WestcoastEducationStudentPortal.Models;
using WestcoastEducationStudentPortal.Services;

namespace WestcoastEducationStudentPortal.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly CoursesService _courseService;
        private readonly StudentsService _studentService;

        public RegistrationController(CoursesService coursesService, StudentsService studentService)
        {
            _courseService = coursesService;
            _studentService = studentService;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegistrateToCourse(int? id)
        {
            if (id == null || _courseService.Get == null)
            {
                return NotFound();
            }

            return View(new RegistrateStudentModel
            {
                Course = await _courseService.Get(id ?? 0),
                Students = await _studentService.GetAll()
            });
        }

        [HttpPost]
        public async Task<IActionResult> RegistrateStudentToCourse([Bind("Course,CourseId,Student,Students]")] RegistrateStudentModel sci)
        {
            //var courseId = (collection["CourseId"]);
            //var studentId = (collection["StudentId"]);
            if (sci.CourseId == null || sci.Student == null)
            {
                return NotFound();
            }

            //var courseId = collection.CourseId;
            //var studentId = 0;


            await _studentService.RegistrateOnCourse(int.Parse(sci.Student), int.Parse(sci.CourseId));

            var course = await _courseService.Get(int.Parse(sci.CourseId));

            return View(course);
        }
    }
}
