using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using EduClick.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using EduClick.Data;

namespace P.EDUCLICK.Controllers
{
    public class RegistroController : Controller
    {
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena, string Rol)
        {
            try
            {
                if (Contrasena != ConfirmarContrasena)
                {
                    ViewBag.Error = "Las contraseñas no coinciden";
                    return View("Index");
                }

                // ✅ CORRECCIÓN 3: Contraseña hasheada con SHA256 antes de guardar
                string contrasenaHash = HashearContrasena(Contrasena);

                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    string query = @"INSERT INTO Usuarios 
                        (Nombres, Apellidos, Correo, Contrasena, Rol, FechaRegistro)
                        VALUES (@Nombres, @Apellidos, @Correo, @Contrasena, @Rol, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasenaHash); // ✅ hash, no texto plano
                        cmd.Parameters.AddWithValue("@Rol", Rol);
                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al registrar el usuario.";
                // En producción: loggear ex.Message con ILogger, no mostrarlo al usuario
                return View("Index");
            }
        }

        public IActionResult Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

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
