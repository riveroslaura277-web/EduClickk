using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduClick.Models
{
    public class AsistenciaEscolar
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Estudiante")]
        public int EstudianteId { get; set; }

        public DateTime Fecha { get; set; }

        public bool Presente { get; set; }

        public bool Tarde { get; set; }

        public Estudiantes? Estudiante { get; set; }
    }
}