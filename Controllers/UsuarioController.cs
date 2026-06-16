using EduClick.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduClick.Controllers
{
    public class UsuarioController : Controller
    {
        // Debes agregar el nombre del método antes de las llaves
        public IActionResult Index()
        {
            return View();
        }
    }
}