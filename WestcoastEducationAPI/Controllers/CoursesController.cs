using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WestcoastEducationAPI.DAL;
using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _repository = courseRepository;
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _repository.GetCourses();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<Course> Get(int id)
        {
            return await _repository.GetCourse(id);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task Post([FromBody] Course course)
        {
            await _repository.AddCourse(course);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Course course)
        {
            await _repository.EditCourse(id, course);
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteCourse(id);
        }
    }
}
