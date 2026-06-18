namespace EduClick.Models
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;

        // Relación: un rol tiene muchos usuarios
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
