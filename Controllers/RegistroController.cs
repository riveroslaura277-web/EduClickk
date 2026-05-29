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
<<<<<<< HEAD
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena)
        {
            // 🔴 VALIDAR CONTRASEÑAS
            if (Contrasena != ConfirmarContrasena)
            {
                TempData["Mensaje"] = "❌ Las contraseñas no coinciden.";
                TempData["Tipo"] = "error";

                return RedirectToAction("Index");
=======
        public async Task<IActionResult> Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena, string Rol)
        {
            // Validaciones
            if (Contrasena.Length < 6)
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
>>>>>>> c92993177020f95f7f9702566506a31b25470f38
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

<<<<<<< HEAD
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", Contrasena);

                        cmd.ExecuteNonQuery();
                    }
                }

                // ✅ MENSAJE ÉXITO
                TempData["Mensaje"] = "✅ Registro exitoso.";
                TempData["Tipo"] = "success";

                return RedirectToAction("Index");
=======
                ViewBag.Success = "Usuario registrado correctamente.";
                return View("Index");
>>>>>>> c92993177020f95f7f9702566506a31b25470f38
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                if (ex.Number == 2627)
                {
                    TempData["Mensaje"] = "⚠️ Este correo ya está registrado.";
                    TempData["Tipo"] = "error";

                    return RedirectToAction("Index");
                }

                TempData["Mensaje"] = "❌ Ocurrió un error al registrar.";
                TempData["Tipo"] = "error";

                return RedirectToAction("Index");
=======
                ViewBag.Error = $"Error al registrar: {ex.Message}";
                return View("Index");
>>>>>>> c92993177020f95f7f9702566506a31b25470f38
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