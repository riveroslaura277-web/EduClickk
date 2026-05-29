using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EduClick.Models;
using System;
using System.Collections.Generic;

namespace EduClick.Controllers
{
    public class RegistroController : Controller
    {
        private readonly string _conexion =
            "Server=DANNA\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;TrustServerCertificate=True;";

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
                        cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                        cmd.Parameters.AddWithValue("@Rol", Rol);
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("Listar");

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
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
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Rol = dr["Rol"].ToString()
                        });
                    }
                }
            }

            return View(lista);
        }

        public IActionResult Eliminar(int id)
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
            return RedirectToAction("Listar");
        }

        [HttpPost]
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
                return Content(ex.Message);
            }
        }
    }
}