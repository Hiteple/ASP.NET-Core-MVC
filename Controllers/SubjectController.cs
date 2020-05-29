using System;
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
            Subject subject = new Subject
            {
                UniqueId = Guid.NewGuid().ToString(),
                Name = "Science"
            };

            ViewBag.Date = DateTime.Now;

            return View(subject);
        }
    }
}