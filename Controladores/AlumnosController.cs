using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class AlumnosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}