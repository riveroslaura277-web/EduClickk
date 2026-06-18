namespace EduClick.Models
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string Materia { get; set; } = string.Empty;

        public Curso Curso { get; set; } = new Curso();
    }
}
