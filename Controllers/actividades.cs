using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class Actividades : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}