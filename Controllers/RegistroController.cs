using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduClick.Data;
using EduClick.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduClick.Controllers
{
    public class RegistroController : Controller
    {
        private readonly EduClickContext _context;

        public RegistroController(EduClickContext context)
        {
            _context = context;
        }

        // CREATE: Registro de usuario
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena, string Rol)
        {
            if (Contrasena != ConfirmarContrasena)
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena)
        {
            if (Contrasena.Length < 6)
            {
                ViewBag.Error = "La contraseña debe tener mínimo 6 caracteres";
                return View("Index");
            }
            else if (Contrasena != ConfirmarContrasena)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View("Index");
            }

            try
            {
                ViewBag.Error = "Las contraseñas no coinciden.";
                return View("Index");
            }

            if (Rol == "Docente" || Rol == "Rector")
            {
                ViewBag.Error = "Este rol solo puede ser creado por un administrador.";
                return View("Index");
            }

            var usuario = new Usuarios
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                Correo = Correo,
                Contrasena = Contrasena,
                Rol = Rol,
                FechaRegistro = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            ViewBag.Success = "Usuario registrado correctamente.";
            return View("Index");
        }

        public async Task<IActionResult> Listar()
        { 
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        public async Task<IActionResult> ListarMisUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.Rol == "Estudiante" || u.Rol == "Acudiente")
                .ToListAsync();
            return View("Listar", usuarios);
        }
        // UPDATE: Editar usuario
        // GET: Registro/Editar/correo
        public async Task<IActionResult> Editar(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                return BadRequest(); // si no llega el correo en la ruta
                ViewBag.Mensaje = "USUARIO REGISTRADO CORRECTAMENTE";
                return View("Index");
            }

            var usuario = await _context.Usuarios
                                        .FirstOrDefaultAsync(u => u.Correo == correo);

            if (usuario == null)
            {
                return NotFound(); // si no existe el usuario con ese correo
            }

            return View(usuario); // devuelve la vista con el modelo encontrado
        }

        // POST: Registro/Editar
        [HttpPost]
        public async Task<IActionResult> Editar(Usuarios usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuarios.Any(u => u.Correo == usuario.Correo))
                if (ex.Number == 2627) 
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


        // DELETE: Eliminar usuario
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Listar");
                ViewBag.Error = $"Error al registrar: {ex.Message}";
                return View("Index");
            }
        }
    }
}
