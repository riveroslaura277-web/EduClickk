namespace EduClick.Models
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public Curso Curso { get; set; } = new Curso();
    }
}
