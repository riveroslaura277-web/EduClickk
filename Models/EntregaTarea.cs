namespace EduClick.Models
{
    public class EntregaTarea
    {
        public int Id { get; set; }

        public string NombreArchivo { get; set; } = string.Empty;

        public string NombreEstudiante { get; set; } = string.Empty;

        public DateTime FechaEntrega { get; set; }
    }
}