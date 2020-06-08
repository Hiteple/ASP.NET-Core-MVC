using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class Course: BaseSchool
    {
        [Required]
        public override string Name { get; set; }
        
        public SchoolTime SchoolTime { get; set; }
        
        public List<Subject> Subjects{ get; set; }
        
        public List<Student> Students{ get; set; }
        public string SchoolId { get; set; }
        
        public School School { get; set; }
        
        public string Address { get; set; }
    }
}