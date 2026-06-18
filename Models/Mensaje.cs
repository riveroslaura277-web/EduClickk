namespace EduClick.Models
{
    public class Mensaje
    {
        public int IdMensaje { get; set; }
        public Usuario Remitente { get; set; } = new Usuario();
        public string Contenido { get; set; } = string.Empty;
    }
}
