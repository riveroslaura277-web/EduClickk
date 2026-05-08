using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
