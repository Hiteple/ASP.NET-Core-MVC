using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}