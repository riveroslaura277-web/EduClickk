using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class actividades : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
