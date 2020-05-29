using System;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            var school = new School();
            school.UniqueId = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.YearOfCreation = 2005;

            ViewBag.DynamicThing = "The Nun";
            
            return View(school);
        }
    }
}