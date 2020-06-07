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
            return View(_context.Students.FirstOrDefault());
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