using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduClick.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        public int IdRol { get; set; } // 🔥 obligatorio

        [ForeignKey("IdRol")]
        public Rol? Rol { get; set; }

        [Required]
        public string Correo { get; set; } = null!;

        [Required]
        public string Nombres { get; set; } = null!;

        [Required]
        public string Apellidos { get; set; } = null!;

        [Column("Contraseña")]
        [Required]
        public string Contrasena { get; set; } = null!;

        public DateTime FechaRegistro { get; set; }
    }
}