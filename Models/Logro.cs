using System;
using System.ComponentModel.DataAnnotations;

namespace EduClick.Models
{
    public class Logro
    {
        [Key]
        public int IdLogro { get; set; }

        public string NombreLogro { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public DateTime FechaObtencion { get; set; } = DateTime.Now;

        // Relación con Estudiante
        public int IdEstudiante { get; set; }
        public DetalleEstudiante Estudiante { get; set; }
    }
}
