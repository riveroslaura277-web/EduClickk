using Microsoft.EntityFrameworkCore;
using EduClick.Models;
using EduClick.Controladores;

namespace EduClick.Data
{
    public class EduClickContext : DbContext
    {
        public EduClickContext(DbContextOptions<EduClickContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<DetalleEstudiante> Estudiantes { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Acudiente> Acudientes { get; set; }
        public DbSet<Rector> Rectores { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }

        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Logro> Logros { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<DetalleEstudiante> DetalleEstudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de precisión para la nota
            modelBuilder.Entity<Evidencia>()
                .Property(e => e.Nota)
                .HasPrecision(3, 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
