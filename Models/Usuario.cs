namespace EduClick.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;

        public Curso Curso { get; set; } = new Curso();
        public Rol Rol { get; set; } = new Rol();
        public ICollection<Calificación> Calificaciones { get; set; } = new List<Calificación>();
    }
}
