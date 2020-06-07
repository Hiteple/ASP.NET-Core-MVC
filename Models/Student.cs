using System;
using System.Collections.Generic;

namespace ASP.Models
{
    public class Student: BaseSchool
    {
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public List<Exam> Exams { get; set; }
    }
}