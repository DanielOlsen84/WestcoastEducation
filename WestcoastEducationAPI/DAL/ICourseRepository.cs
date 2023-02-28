using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.DAL
{
    public interface ICourseRepository
    {
        public Task AddCourse(Course course);
        public Task<List<Course>> GetCourses();
        public Task<Course> GetCourse(int id);
        public Task EditCourse(int id, Course course);
        public Task DeleteCourse(int id);
    }
}
