using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using EduClick.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using EduClick.Data;
=======
using Microsoft.Data.SqlClient;
>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56

namespace P.EDUCLICK.Controllers
{
    public class RegistroController : Controller
    {
<<<<<<< HEAD
        // ✅ CORRECCIÓN 1: Cadena de conexión leída desde appsettings.json, no hardcodeada
        private readonly string _conexion;

        // ✅ CORRECCIÓN 2: _context declarado correctamente (si lo necesitas para otras vistas)
        private readonly EduClickContext _context;

        public RegistroController(EduClickContext context, IConfiguration configuration)
        {
            _context = context;
            _conexion = configuration.GetConnectionString("Default")!;
        }

        // GET: Registro
=======
        private readonly string _conexion =
            "Server=LAPTOP-2IVQ34EB\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;TrustServerCertificate=True;";

>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
<<<<<<< HEAD
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena, string Rol)
        {
            try
            {
                if (Contrasena != ConfirmarContrasena)
=======
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena)
        {
            // 🔴 VALIDAR CONTRASEÑAS
            if (Contrasena != ConfirmarContrasena)
            {
                TempData["Mensaje"] = "❌ Las contraseñas no coinciden.";
                TempData["Tipo"] = "error";

                return RedirectToAction("Index");
            }


        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena)
        {
 master
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
                {
                    ViewBag.Error = "Las contraseñas no coinciden";
                    return View("Index");
                }

                // ✅ CORRECCIÓN 3: Contraseña hasheada con SHA256 antes de guardar
                string contrasenaHash = HashearContrasena(Contrasena);

<<<<<<< HEAD
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    string query = @"INSERT INTO Usuarios 
                        (Nombres, Apellidos, Correo, Contrasena, Rol, FechaRegistro)
                        VALUES (@Nombres, @Apellidos, @Correo, @Contrasena, @Rol, GETDATE())";

=======
>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
<<<<<<< HEAD
                        cmd.Parameters.AddWithValue("@Contrasena", contrasenaHash); // ✅ hash, no texto plano
                        cmd.Parameters.AddWithValue("@Rol", Rol);
=======
                        cmd.Parameters.AddWithValue("@Contrasena", Contrasena);

>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
                        cmd.ExecuteNonQuery();
                    }
                }

<<<<<<< HEAD
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al registrar el usuario.";
                // En producción: loggear ex.Message con ILogger, no mostrarlo al usuario
                return View("Index");
=======
                // ✅ MENSAJE ÉXITO
                TempData["Mensaje"] = "✅ Registro exitoso.";
                TempData["Tipo"] = "success";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.Number == 2627)
                {
                    TempData["Mensaje"] = "⚠️ Este correo ya está registrado.";
                    TempData["Tipo"] = "error";

                    return RedirectToAction("Index");
                }

                TempData["Mensaje"] = "❌ Ocurrió un error al registrar.";
                TempData["Tipo"] = "error";

                return RedirectToAction("Index");
>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
            }
        }

        public IActionResult Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

<<<<<<< HEAD
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                con.Open();
                string query = "SELECT Id, Nombres, Apellidos, Correo, Rol FROM Usuarios";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuarios
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombres = dr["Nombres"].ToString()!,
                            Apellidos = dr["Apellidos"].ToString()!,
                            Correo = dr["Correo"].ToString()!,
                            Rol = dr["Rol"].ToString()!
                        });
                    }
                }
            }

            return View(lista);
        }

        // ✅ CORRECCIÓN 4: Eliminar como POST para evitar borrados accidentales por GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();
                    string query = "DELETE FROM Usuarios WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // En producción: loggear con ILogger
                TempData["Error"] = "No se pudo eliminar el usuario.";
            }

            return RedirectToAction("Listar");
=======
                    con.Open();
 master

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
>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarInline(int Id, string Nombres, string Apellidos, string Correo, string Rol)
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
                                 Rol=@Rol
                             WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Rol", Rol);
                        cmd.ExecuteNonQuery();
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                // En producción: loggear con ILogger
                return StatusCode(500, "Error al actualizar el usuario.");
            }
        }

        // ✅ CORRECCIÓN 3 (helper): Método privado para hashear contraseñas
        private static string HashearContrasena(string contrasena)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(contrasena));
            return Convert.ToHexString(bytes).ToLower();
        }
    }
}
