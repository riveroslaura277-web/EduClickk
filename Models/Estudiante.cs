namespace EduClick.Models
{
    public class Estudiante
    {
   
            public int Id { get; set; }              // PK
            public int Edad { get; set; }
            public string? Grado { get; set; }

            // FK hacia Usuario
            public int UsuarioId { get; set; }
            public Usuarios? Usuario { get; set; }     // navegación
        }
    }



