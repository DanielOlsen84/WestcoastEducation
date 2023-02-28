using Microsoft.EntityFrameworkCore;
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
            return await ctx.Students.FindAsync(id);
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

            var studentCourse = new StudentCourse { StudentId = studentId, CourseId = courseId };
            ctx.StudentCourses.Add(studentCourse);

            oldstudent.RegistratedCourses.Add(studentCourse);

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
