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
        [Route("Subject/Index")]
        [Route("Subject/Index/{subjectId}")]
        public IActionResult Index(string subjectId)
        {
            if (!string.IsNullOrWhiteSpace(subjectId))
            {
                var subject = from sub in _context.Subjects where sub.Id == subjectId select sub;
                return View(subject.SingleOrDefault());
            }
            return View("MultipleSubject", _context.Subjects);
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