using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {
            return View("Docente");
        }
    }
}
