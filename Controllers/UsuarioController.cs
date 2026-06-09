using EduClick.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduClick.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly EduClickContext _context;

        public UsuarioController(EduClickContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult IniciarConGoogle(string rol)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("CallbackGoogle", "Usuario"),
                Items = { { "rol", rol } }
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> CallbackGoogle(string rolSeleccionado)
        {
            var result = await HttpContext.AuthenticateAsync(
                GoogleDefaults.AuthenticationScheme);

            if (!result.Succeeded)
                return RedirectToAction("Index", "Home");

            var email = result.Principal?.FindFirst(ClaimTypes.Email)?.Value;
            string rolSeleccionado = "";
            if (result.Properties?.Items.ContainsKey("rol") == true)
                result.Properties.Items.TryGetValue("rol", out rolSeleccionado);
            rolSeleccionado = rolSeleccionado ?? string.Empty;

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == email && u.Rol == rolSeleccionado);

            if (usuario == null)
            {
                TempData["Error"] = $"El correo {email ?? "desconocido"} no está registrado como {rolSeleccionado} en EduClick.";
                return RedirectToAction("Index", "Home"); // ← faltaba este return
            }

            // Guardar sesión
            HttpContext.Session.SetString("UsuarioEmail", email ?? "");
            HttpContext.Session.SetString("UsuarioRol", rolSeleccionado);
            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

            return rolSeleccionado switch
            {
                "Administrador" => RedirectToAction("LoginAdministrador", "Usuario"),
                "Rector" => RedirectToAction("RolRector", "Rector"),
                "Docente" => RedirectToAction("docente", "Docente"),
                "Estudiante" => RedirectToAction("Index", "Alumnos"),
                "Acudiente" => RedirectToAction("LoginAcudiente", "Usuario"),
                _ => RedirectToAction("Index", "Home")
            };
        }

        public IActionResult OlvideContrasena()
        {
            return View();
        }
    }
}