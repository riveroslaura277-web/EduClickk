using System.Security.Cryptography.Xml;

namespace EduClick.Models
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; } = string.Empty;

        public ICollection<Usuario> Estudiantes { get; set; } = new List<Usuario>();
        public ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
    }
}
