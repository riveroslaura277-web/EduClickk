namespace EduClick.Models
{

    public class Acudiente
        {
            public int Id { get; set; }
            public string? Telefono { get; set; }
            public string? Direccion { get; set; }

            // Clave foránea hacia Usuarios
            public int UsuarioId { get; set; }

            // Propiedad de navegación (puede ser nula)
            public Usuarios? Usuario { get; set; }
        }
    }


