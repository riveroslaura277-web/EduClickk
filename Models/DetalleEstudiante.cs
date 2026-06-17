using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduClick.Models
{
    [Table("DetalleEstudiantes")]
    public class DetalleEstudiante
    {
        [Key]
        public int IdDetalle { get; set; }

        public int IdEstudiante { get; set; }

        [ForeignKey("IdEstudiante")]
        public Estudiante Estudiante { get; set; }

        // Campos adicionales
        public string Codigo { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int Grado { get; set; }
        public string Estado { get; set; } = "Activo";
        public string? Correo { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string? Curso { get; set; }


        // Relación: un detalle de estudiante puede tener muchas evidencias
        public ICollection<Evidencia> Evidencias { get; set; } = new List<Evidencia>();
    }
}
