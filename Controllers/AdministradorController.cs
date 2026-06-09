using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult admin ()
        {
            return View();
        }
    }
}
