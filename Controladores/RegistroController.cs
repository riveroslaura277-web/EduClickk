using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace P.EDUCLICK.Controllers
{
    public class RegistroController : Controller
    {
        private readonly string _conexion =
            "Server=LAPTOP-2IVQ34EB\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;TrustServerCertificate=True;";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    string query = @"INSERT INTO Usuarios 
                                     (Nombres, Apellidos, Correo, Contrasena, FechaRegistro) 
                                     VALUES (@Nombres, @Apellidos, @Correo, @Contrasena, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", Contrasena);

                        cmd.ExecuteNonQuery();
                    }
                }

             
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
               
                if (ex.Number == 2627)
                {
                    ViewBag.Error = "Este correo ya está registrado por otro usuario.";
                    return View("Index");
                }

              
                ViewBag.Error = "Ocurrió un error al registrar el usuario.";
                return View("Index");
            }
        }
    }
}
