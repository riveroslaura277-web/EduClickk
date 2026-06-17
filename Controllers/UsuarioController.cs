using Microsoft.AspNetCore.Mvc;
using EduClick.Services;

namespace EduClick.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public IActionResult Login(string rol)
        {
            ViewBag.RolSeleccionado = rol;
            return View("Inicio");
        }


                [HttpPost]
        public IActionResult Login(string email, string password, string rol)
        {
            var usuario = _usuarioService.ValidarUsuario(email, password);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
                return View("Inicio");
            }

            // Validar que el rol seleccionado coincida
            if ((rol == "Acudiente" && usuario.IdRol != 4) ||
                (rol == "Estudiante" && usuario.IdRol != 5) ||
                (rol == "Docente" && usuario.IdRol != 3) ||
                (rol == "Rector" && usuario.IdRol != 2) ||
                (rol == "Administrador" && usuario.IdRol != 1))
            {
                ModelState.AddModelError("", "Este usuario no pertenece al rol seleccionado.");
                return View("Inicio");
            }

            switch (usuario.IdRol)
            {
                case 1: return RedirectToAction("Dashboard", "Admin");
                case 2: return RedirectToAction("Index", "Rector");
                case 3: return RedirectToAction("Index", "Docente");
                case 4: return RedirectToAction("Padres", "Acudiente");
                case 5: return RedirectToAction("Dashboard", "Estudiante");
                default: return RedirectToAction("Index", "Home");
            }
        }
    }
}