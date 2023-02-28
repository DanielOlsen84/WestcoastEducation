using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.DAL
{
    public interface ITeacherRepository
    {
        public Task AddTeacher(Teacher teacher);
        public Task<List<Teacher>> GetTeachers();
        public Task<Teacher> GetTeacher(int id);
        public Task EditTeacher(int id, Teacher teacher);
        public Task DeleteTeacher(int id);
    }
}
