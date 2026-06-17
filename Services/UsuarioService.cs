using EduClick.Data;
using EduClick.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace EduClick.Services
{
    public class UsuarioService
    {
        private readonly EduClickContext _context;

        public UsuarioService(EduClickContext context)
        {
            _context = context;
        }

        // 🔐 Método para hashear la contraseña
        private string HashearContrasena(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // ✅ Método para validar usuario
        public Usuarios? ValidarUsuario(string email, string password)
        {
            var hash = HashearContrasena(password);

            Console.WriteLine("EMAIL: " + email);
            Console.WriteLine("HASH: " + hash);

            return _context.Usuarios
                .Include(x => x.Rol)
                .FirstOrDefault(x => x.Correo == email && x.Contrasena == hash);
        }
    }
}