namespace WestcoastEducationStudentPortal.Models
{
    public class RegistrateStudentModel
    {
        public Course Course { get; set; }
        public string CourseId { get; set; }
        public string Student { get; set; }
        public List<Student> Students { get; set; }
    }

    public class StudentCourseIds
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}
