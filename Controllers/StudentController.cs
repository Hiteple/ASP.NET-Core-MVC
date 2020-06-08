using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class StudentController: Controller
    {
        // GET
        [Route("Student/Index")]
        [Route("Student/Index/{studentId}")]
        public IActionResult Index(string studentId)
        {
            if (!string.IsNullOrWhiteSpace(studentId))
            {
                var student = from stu in _context.Students where stu.Id == studentId select stu;
                return View(student.SingleOrDefault());
            }
            return View("MultipleStudent", _context.Students);
        }
        public IActionResult MultipleStudent()
        {
            ViewBag.Date = DateTime.Now;

            return View("MultipleStudent", _context.Students);
        }

        private SchoolContext _context;
        
        public StudentController(SchoolContext context)
        {
            _context = context;
        }
    }
}