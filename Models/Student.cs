using System;
using System.Collections.Generic;

namespace ASP.Models
{
    public class Student: BaseSchool
    {
        public List<Exam> Exams { get; set; } = new List<Exam>();
    }
}