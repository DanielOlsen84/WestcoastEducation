using Microsoft.AspNetCore.Mvc;
using WestcoastEducationAPI.DAL;
using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _repository = teacherRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _repository.GetTeachers();
        }

        [HttpGet("{id}")]
        public async Task<Teacher> Get(int id)
        {
            return await _repository.GetTeacher(id);
        }

        // POST: TeachersController/Create
        [HttpPost]
        public async Task Post([FromBody] Teacher teacher)
        {
            await _repository.AddTeacher(teacher);
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Teacher teacher)
        {
            await _repository.EditTeacher(id, teacher);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _repository.DeleteTeacher(id);
        }
    }
}
