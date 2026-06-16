using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduClick.Models
{
   // 👈 nombre exacto de la tabla en SQL
    public class Estudiantes
    {
        [Key]
        public int IdEstudiante { get; set; }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Documento { get; set; }
        public string? Curso { get; set; }

        // Relaciones
        public int IdUsuario { get; set; }
        public int IdAcudiente { get; set; }

        // Propiedades de navegación (si quieres usar EF Core con Include)
        public Usuarios? Usuario { get; set; }
        public Acudiente? Acudiente { get; set; }
    }
}
