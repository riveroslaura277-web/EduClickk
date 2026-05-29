using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduClick.Data;
using EduClick.Models;

namespace EduClick.Controllers
{
    public class RegistroController : Controller
    {
        private readonly EduClickContext _context;

        public RegistroController(EduClickContext context)
        {
            _context = context;
        }

        // GET: Registro
        public IActionResult Index()
        {
            return View();
        }

        // POST: Registrar usuario
        [HttpPost]
        public async Task<IActionResult> Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena, string Rol)
        {
            // Validaciones
            if (string.IsNullOrEmpty(Contrasena) || Contrasena.Length < 6)
            {
                ViewBag.Error = "La contraseña debe tener mínimo 6 caracteres";
                return View("Index");
            }

            if (Contrasena != ConfirmarContrasena)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View("Index");
            }

            if (Rol == "Docente" || Rol == "Rector")
            {
                ViewBag.Error = "Este rol solo puede ser creado por un administrador.";
                return View("Index");
            }

            try
            {
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
            catch (Exception ex)
            {
                // Verifica si el error es por correo duplicado (código de error SQL)
                if (ex.InnerException != null && ex.InnerException.Message.Contains("2627"))
                {
                    ViewBag.Error = "Este correo ya está registrado.";
                }
                else
                {
                    ViewBag.Error = $"Error al registrar: {ex.Message}";
                }
                return View("Index");
            }
        }

        // LISTAR
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

        // GET: Editar
        public async Task<IActionResult> Editar(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Editar
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
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Listar");
        }
    }
}