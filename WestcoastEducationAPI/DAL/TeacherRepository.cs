using Microsoft.EntityFrameworkCore;
using WestcoastEducationAPI.Models;

namespace WestcoastEducationAPI.DAL
{
    public class TeacherRepository : ITeacherRepository
    {
        public async Task AddTeacher(Teacher teacher)
        {
            var ctx = new Context();

            ctx.Teachers.Add(teacher);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            var ctx = new Context();
            return await ctx.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            var ctx = new Context();
            return await ctx.Teachers.FindAsync(id);
        }

        public async Task EditTeacher(int id, Teacher teacher)
        {
            var ctx = new Context();

            var oldteacher = ctx.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id).Result;

            if (oldteacher == null)
            {
                return;
            }

            oldteacher.TeacherId = teacher.TeacherId;
            oldteacher.FirstName = teacher.FirstName;
            oldteacher.LastName = teacher.LastName;
            oldteacher.Email = teacher.Email;
            oldteacher.Phone = teacher.Phone;
            oldteacher.Address = teacher.Address;
            oldteacher.Competence = teacher.Competence;

            ctx.Teachers.Update(oldteacher);

            await ctx.SaveChangesAsync();
        }

        public async Task DeleteTeacher(int id)
        {
            var ctx = new Context();

            var teacher = await ctx.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);

            if (teacher == null)
            {
                return;
            }

            ctx.Teachers.Remove(teacher);
            await ctx.SaveChangesAsync();
        }
    }
}
