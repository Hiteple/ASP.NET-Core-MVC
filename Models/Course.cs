using System;
using System.Collections.Generic;

namespace ASP.Models
{
    public class Course: BaseSchool
    {
        public SchoolTime SchoolTime { get; set; }
        public List<Subject> Subjects{ get; set; }
        public List<Student> Students{ get; set; }
        public string Address { get; set; }
    }
}