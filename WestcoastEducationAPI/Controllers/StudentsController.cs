using Microsoft.AspNetCore.Mvc;
using WestcoastEducationAPI.DAL;
using WestcoastEducationAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WestcoastEducationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly ICourseRepository _courseRepository;

        public StudentsController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _repository = studentRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {

            return await _repository.GetStudents();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            var student = await _repository.GetStudent(id);
            //var courses = await _courseRepository.GetCourses();

            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task Post([FromBody] Student student)
        {
            await _repository.AddStudent(student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Student student)
        {
            await _repository.EditStudent(id, student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteStudent(id);
        }

        [HttpPost("{studentId}")]
        public async Task RegistrateOnCourse(int studentId, [FromBody] int courseId)
        {
            await _repository.RegistrateStudentOnCourse(studentId, courseId);
        }
    }
}
