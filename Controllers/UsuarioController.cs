using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Inicio");
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Debes llenar todos los campos.");
                return View("Inicio");
            }

            var usuario = _usuarioService.ValidarUsuario(email, password);

            if (usuario == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View("Inicio");
            }

            ViewBag.Error = $"Usuario encontrado. Rol: {usuario.IdRol}";

            // Guardar datos en sesión
            HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
            HttpContext.Session.SetInt32("IdRol", usuario.IdRol);

            // Redirigir según el rol
            switch (usuario.IdRol)
            {
                case 1:
                    return RedirectToAction("Dashboard", "Admin");

                case 2:
                    return RedirectToAction("Index", "Rector");

                case 3:
                    return RedirectToAction("Index", "Docente");

                case 4:
                    return RedirectToAction("Padres", "Acudiente");

                case 5:
                    return RedirectToAction("Dashboard", "Estudiante");

                default:
                    return RedirectToAction("Inicio", "Home");
            }
        }

        // Cerrar sesión
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}