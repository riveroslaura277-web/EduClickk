namespace EduClick.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relación con Curso
        public int CursoId { get; set; }
        public Curso Curso { get; set; } = new Curso();
    }
}
