namespace EduClick.Models
{
    public class MateriaViewModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Grado { get; set; }
        public string Docente { get; set; } = string.Empty;
        public int HorasSemana { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
