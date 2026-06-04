using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class UsuarioController : Controller
    {
        // Eliminamos el _context temporalmente para que no busque la base de datos

        [HttpGet]
        public IActionResult Login(string rol)
        {
            ViewBag.RolSeleccionado = rol;
            return View("Inicio");
        }

        [HttpPost]
        public IActionResult Login(string email, string password, string rol)
        {
            // Validamos que los campos no estén vacíos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Debes llenar todos los campos.");
                ViewBag.RolSeleccionado = rol;
                return View("Inicio");
            }

            // SIMULACIÓN: Aquí saltamos la BD. 
            // Si el correo contiene algo, consideramos que es un usuario válido.
            bool usuarioValido = true;

            if (usuarioValido)
            {
                // Redirigimos directamente según el rol
                switch (rol)
                {
                    case "Docente":
                        return RedirectToAction("Index", "Docente");
                    case "Estudiante":
                        return RedirectToAction("Index", "Estudiante");
                    case "Rector":
                        return RedirectToAction("Index", "Rector");
                    case "Acudiente":
                        return RedirectToAction("Index", "Acudiente");
                    case "Administrador":
                        return RedirectToAction("Index", "Administrador");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }

            return View("Inicio");
        }
    }
}