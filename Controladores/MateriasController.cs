using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class MateriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}