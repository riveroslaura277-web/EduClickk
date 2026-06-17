using EduClick.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduClick.Models
{
    [Table("Evidencias")]
    public class Evidencia
    {
        [Key]
        public int Id { get; set; }  
        public int IdDetalle { get; set; }
        public int DetalleEstudiante { get; set; }
        public string NombreArchivo { get; set; } = string.Empty;
        public string NombreEstudiante { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Pendiente";
        public decimal? Nota { get; set; }
        public string? Observacion { get; set; }
        public string? MensajeConfirmacion { get; set; }

        public int IdEstudiante { get; set; }

        [ForeignKey("IdEstudiante")]
        public Estudiantes? Estudiante { get; set; }
    }
}