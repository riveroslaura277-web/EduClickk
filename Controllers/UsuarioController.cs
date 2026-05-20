using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            // Validación básica: campos vacíos
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "Debes llenar todos los campos.");
                return View("Inicio"); // vuelve a la vista de login
            }

            // Validación de credenciales (ejemplo)
            if (Email == "admin@correo.com" && Password == "1234")
            {
                // ✅ Si son correctos → redirige a Roles
                return RedirectToAction("FondoRoles", "Roles");
            }

            // ❌ Si no coinciden → error
            ModelState.AddModelError("", "Correo o contraseña incorrectos.");
            return View("Inicio");
        }
    }
}
