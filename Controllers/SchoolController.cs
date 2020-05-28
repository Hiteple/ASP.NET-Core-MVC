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
            school.SchoolId = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.Year = 2005;
            
            return View(school);
        }
    }
}