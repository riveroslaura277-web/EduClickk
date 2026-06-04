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
        private readonly string _conexion = "Server=LAPTOP-2IVQ34EB\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;TrustServerCertificate=True;";

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
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena, string Rol)
        {
            // 1. Validaciones básicas
            if (Contrasena != ConfirmarContrasena)
            {
                ViewBag.Error = "❌ Las contraseñas no coinciden.";
                return View("Index");
            }

            if (string.IsNullOrEmpty(Nombres) || string.IsNullOrEmpty(Correo))
            {
                ViewBag.Error = "Todos los campos son obligatorios.";
                return View("Index");
            }

            try
            {
                string hash = HashearContrasena(Contrasena);

                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    // Ajusta el INSERT según los nombres reales de tus columnas en SQL
                    string query = @"INSERT INTO Usuarios (Nombres, Apellidos, Correo, Contrasena, Rol, FechaRegistro) 
                                     VALUES (@Nombres, @Apellidos, @Correo, @Contrasena, @Rol, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                        cmd.Parameters.AddWithValue("@Rol", Rol);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Éxito
                TempData["Mensaje"] = "✅ Registro exitoso.";
                TempData["Tipo"] = "success";
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                // Error 2627 es el código de SQL para violación de llave única (correo duplicado)
                if (ex.Number == 2627)
                {
                    ViewBag.Error = "⚠️ Este correo ya está registrado.";
                }
                else
                {
                    ViewBag.Error = "❌ Ocurrió un error al registrar: " + ex.Message;
                }
                return View("Index");
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