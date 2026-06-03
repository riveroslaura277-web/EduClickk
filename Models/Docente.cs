namespace EduClick.Models
{

    public class Docente
        {
            public int Id { get; set; }
            public string? Materia { get; set; }
            public string? Direccion { get; set; }

            public int UsuarioId { get; set; }
            public Usuarios? Usuario { get; set; }
        }
    }


