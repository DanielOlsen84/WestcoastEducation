using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.DAL
{
    public class StudentRepository : IStudentRepository
    {
        public async Task AddStudent(Student student)
        {
            var ctx = new Context();

            ctx.Students.Add(student);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Student>> GetStudents()
        {
            var ctx = new Context();
            return await ctx.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            var ctx = new Context();
            var student = await ctx.Students.Include(x => x.Courses).FirstAsync(x => x.StudentId == id);
            
            return student;
        }

        public async Task EditStudent(int id, Student student)
        {
            var ctx = new Context();
            var oldstudent = ctx.Students.FirstOrDefaultAsync(x => x.StudentId == id).Result;

            if (oldstudent == null)
            {
                return;
            }

            oldstudent.StudentId = student.StudentId;
            oldstudent.FirstName = student.FirstName;
            oldstudent.LastName = student.LastName;
            oldstudent.Email = student.Email;
            oldstudent.PhoneNumber = student.PhoneNumber;
            oldstudent.Address = student.Address;

            ctx.Students.Update(oldstudent);

            await ctx.SaveChangesAsync();
        }

        public async Task RegistrateStudentOnCourse(int studentId, int courseId)
        {
            var ctx = new Context();
            var oldstudent = ctx.Students.FirstOrDefaultAsync(x => x.StudentId == studentId).Result;

            if (oldstudent == null)
            {
                return;
            }

            var course = ctx.Courses.FirstOrDefaultAsync(x => x.CourseId == courseId).Result;

            if (course == null)
            {
                return;
            }

            if (oldstudent.Courses == null)
            {
                oldstudent.Courses = new List<Course>();
            }

            oldstudent.Courses.Add(course);
            ctx.Students.Update(oldstudent);
            
            await ctx.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var ctx = new Context();

            var student = await ctx.Students.FirstOrDefaultAsync(x => x.StudentId == id);

            if (student == null)
            {
                return;
            }

            ctx.Students.Remove(student);
            await ctx.SaveChangesAsync();
        }
    }
}
