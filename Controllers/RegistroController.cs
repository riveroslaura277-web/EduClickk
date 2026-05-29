using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace P.EDUCLICK.Controllers
{
    public class RegistroController : Controller
    {
        private readonly string _conexion = "Server=LAPTOP-2IVQ34EB\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;TrustServerCertificate=True;";

        public IActionResult Index()
        {
            return View();
        }

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
        }
    }
}