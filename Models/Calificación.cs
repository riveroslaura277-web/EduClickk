namespace EduClick.Models
{
    public class Calificación
    {
        public int IdCalificacion { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        public Usuario Usuario { get; set; } = new Usuario();
    }
}
