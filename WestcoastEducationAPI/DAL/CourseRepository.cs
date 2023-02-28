using Microsoft.EntityFrameworkCore;
using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.DAL
{
    public class CourseRepository: ICourseRepository
    {

        public async Task AddCourse(Course course)
        {
            var ctx = new Context();

            ctx.Courses.Add(course);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Course>> GetCourses()
        {
            var ctx = new Context();
            return await ctx.Courses.ToListAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            var ctx = new Context();
            return await ctx.Courses.FindAsync(id);
        }

        public async Task EditCourse(int id, Course course)
        {
            var ctx = new Context();

            var oldCourse = ctx.Courses.FirstOrDefaultAsync(x => x.CourseId == id).Result;

            if (oldCourse == null)
            {
                return;
            }

            oldCourse.CourseId = course.CourseId;
            oldCourse.Title = course.Title;
            oldCourse.Lenght = course.Lenght;
            oldCourse.Category = course.Category;
            oldCourse.Description = course.Description;
            oldCourse.Details = course.Details;

            ctx.Courses.Update(oldCourse);

            await ctx.SaveChangesAsync();
        }

        public async Task DeleteCourse(int id)
        {
            var ctx = new Context();

            var course = await ctx.Courses.FirstOrDefaultAsync(x => x.CourseId == id);

            if (course == null)
            {
                return;
            }

            ctx.Courses.Remove(course);
            await ctx.SaveChangesAsync();
        }
    }
}
