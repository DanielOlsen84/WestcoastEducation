﻿namespace WestcoastEducationAdministration.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<StudentCourse> RegistratedCourses { get; set; } = new List<StudentCourse>();
    }
}
