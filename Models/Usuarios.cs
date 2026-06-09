using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduClick.Models
{
    public class Usuarios 

        {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Nombres { get; set; }
            public string? Apellidos { get; set; }
            public string? Contrasena { get; set; }
            public int?IdRol { get; set; }
            public DateTime FechaRegistro { get; set; }
        }

    }


