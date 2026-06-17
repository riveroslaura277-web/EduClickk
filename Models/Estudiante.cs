using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduClick.Models
{
    [Table("Estudiantes")]
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        // Datos principales
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string Curso { get; set; } = string.Empty;

        // Estado académico
        public string Estado { get; set; } = "Activo";
        public int Grado { get; set; }   // mejor como entero

        // Campos adicionales
        public int IdUsuario { get; set; }
        public int IdAcudiente { get; set; }

        // Relación: un estudiante puede tener muchos detalles
        public ICollection<DetalleEstudiante> Detalles { get; set; } = new List<DetalleEstudiante>();

        // Relación: un estudiante puede tener muchas evidencias
        public ICollection<Evidencia> Evidencias { get; set; } = new List<Evidencia>();
    }
}
