using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class CourseController: Controller
    {
        // GET
        [Route("Course/Index")]
        [Route("Course/Index/{courseId}")]
        public IActionResult Index(string courseId)
        {
            if (!string.IsNullOrWhiteSpace(courseId))
            {
                var course = from cou in _context.Courses where cou.Id == courseId select cou;
                return View(course.SingleOrDefault());
            }
            return View("MultipleCourses", _context.Courses);
        }
        public IActionResult MultipleCourse()
        {
            ViewBag.Date = DateTime.Now;

            return View("MultipleCourses", _context.Courses);
        }
        
        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;

            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Course course)
        {
            ViewBag.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                var school = _context.Schools.FirstOrDefault();
                if (school != null) course.SchoolId = school.Id;
                _context.Courses.Add(course);
                _context.SaveChanges();
                return View();  
            }

            return View(course);
        }

        private SchoolContext _context;
        
        public CourseController(SchoolContext context)
        {
            _context = context;
        }
    }
}