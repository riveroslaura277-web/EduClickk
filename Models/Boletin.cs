namespace EduClick.Models
{
    public class Boletines
    {
        public int Id { get; set; }

        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; } = new Estudiante();

        public int PeriodoId { get; set; }
        public Periodos Periodo { get; set; } = new Periodos();

        public string Observaciones { get; set; } = string.Empty;
    }
}
