namespace EduClick.Models
{
    public class Reporte
    {
        public int IdReporte { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;

        public Usuario Usuario { get; set; } = new Usuario();
    }
}
