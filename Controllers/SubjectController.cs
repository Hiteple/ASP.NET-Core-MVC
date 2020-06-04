using System;
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
            Subject mySubject = new Subject {Name = "Math", Id = Guid.NewGuid().ToString()};
            
            return View(mySubject);
        }
        public IActionResult MultipleSubject()
        {
            List<Subject> subjectList = new List<Subject>()
            {
                new Subject {Name = "Math", Id = Guid.NewGuid().ToString()},
                new Subject {Name = "Science", Id = Guid.NewGuid().ToString()},
                new Subject {Name = "Spanish", Id = Guid.NewGuid().ToString()},
                new Subject {Name = "English", Id = Guid.NewGuid().ToString()},
            };

            ViewBag.Date = DateTime.Now;

            return View("MultipleSubject", subjectList);
        }
    }
}