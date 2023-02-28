using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.DAL
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task DeleteStudent(int id);
        Task EditStudent(int id, Student student);
        Task<Student> GetStudent(int id);
        Task<List<Student>> GetStudents();
        Task RegistrateStudentOnCourse(int studentId, int courseId);
    }
}