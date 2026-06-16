using System;
using System.ComponentModel.DataAnnotations;

namespace EduClick.Models // <--- ¡IMPORTANTE! Esto debe coincidir con el nombre de tu proyecto
{
    public class Entrega
    {
        [Key]
        public int IdEntrega { get; set; }
        public int IdEstudiante { get; set; }
        public int IdTarea { get; set; }
        public string ArchivoRuta { get; set; }
        public decimal? Calificacion { get; set; }
        public string Observaciones { get; set; }

        public string NombreArchivo { get; set; }

        public DateTime FechaEntrega{ get; set; }

        public string Estado { get; set; }

        public decimal Nota { get; set; }


        public string MensajeConfirmacion { get; set; }
    }
}

