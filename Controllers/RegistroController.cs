using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EduClick.Data;
using System.Security.Cryptography;
using System.Text;

namespace EduClick.Controllers
{
    public class RegistroController : Controller
    {
        private readonly string _conexion;
        private readonly EduClickContext _context;

        public RegistroController(EduClickContext context, IConfiguration configuration)
        {
            _context = context;
            _conexion = configuration.GetConnectionString("Default")!;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // REGISTRAR
        [HttpPost]
        public IActionResult Registrar(
            string Nombres,
            string Apellidos,
            string Correo,
            string Contrasena,
            string ConfirmarContrasena,
            int IdRol)
        {
            if (Contrasena != ConfirmarContrasena)
            {
                ViewBag.Error = "Las contraseñas no coinciden.";
                return View("Index");
            }

            try
            {
                string hash = HashearContrasena(Contrasena);

                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    string query = @"INSERT INTO Usuarios
                                    (Nombres,Apellidos,Correo,Contrasena,IdRol,FechaRegistro)
                                     VALUES
                                    (@Nombres,@Apellidos,@Correo,@Contrasena,@IdRol,GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", hash);
                        cmd.Parameters.AddWithValue("@IdRol", IdRol);

                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index");
            }
        }

        // LISTAR

        public async Task<IActionResult> Listar()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }




        // EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarInline(
            int IdUsuario,
            string Nombres,
            string Apellidos,
            string Correo,
            int IdRol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    string query = @"UPDATE Usuarios
                             SET Nombres=@Nombres,
                                 Apellidos=@Apellidos,
                                 Correo=@Correo,
                                 IdRol=@IdRol
                             WHERE IdUsuario=@IdUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@IdRol", IdRol);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            return Json(new
                            {
                                success = true,
                                message = "Usuario actualizado"
                            });
                        }

                        return Json(new
                        {
                            success = false,
                            message = "No se encontró el usuario"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarVarios(List<int> ids)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    foreach (var id in ids)
                    {
                        string query = "DELETE FROM Usuarios WHERE IdUsuario = @Id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // ELIMINAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    string query = "DELETE FROM Usuarios WHERE IdUsuario = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // HASH
        private static string HashearContrasena(string contrasena)
        {
            byte[] bytes = SHA256.HashData(
                Encoding.UTF8.GetBytes(contrasena));

            return Convert.ToHexString(bytes).ToLower();
        }
    }
}