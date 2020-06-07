using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class SubjectController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(_context.Subjects.FirstOrDefault());
        }
        public IActionResult MultipleSubject()
        {
            ViewBag.Date = DateTime.Now;

            return View("MultipleSubject", _context.Subjects);
        }
        
        private SchoolContext _context;
        
        public SubjectController(SchoolContext context)
        {
            _context = context;
        }
    }
}