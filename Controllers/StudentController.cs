using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class StudentController : Controller
    {
        // GET
        public IActionResult Index()
        {
            Student myStudent = new Student {Name = "Lawrence", Id = Guid.NewGuid().ToString()};
            
            return View(myStudent);
        }
        public IActionResult MultipleStudent()
        {
            List<Student> students = GenerateStudents();
            ViewBag.Date = DateTime.Now;

            return View("MultipleStudent", students);
        }
        
        private List<Student> GenerateStudents()
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastname1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var studentList = from n1 in name1
                from n2 in name2
                from a1 in lastname1
            select new Student { Name = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return studentList.OrderBy((al) => al.Id).ToList();
        }
    }
}