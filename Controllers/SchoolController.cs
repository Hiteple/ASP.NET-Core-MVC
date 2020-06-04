using System;
using System.Linq;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class SchoolController : Controller
    {
        private SchoolContext _context;
        public IActionResult Index()
        {
            var school = _context.Schools.FirstOrDefault();
            ViewBag.DynamicThing = "The Nun";
            return View(school);
        }

        public SchoolController(SchoolContext context)
        {
            _context = context;
        }
    }
}