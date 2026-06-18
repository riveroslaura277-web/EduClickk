using Microsoft.EntityFrameworkCore;
using EduClick.Models;
using AspNetCoreGeneratedDocument;


namespace EduClick.Data
{
    public class EduClickContext : DbContext
    {
        public EduClickContext(DbContextOptions<EduClickContext> options) : base(options) { }

        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Acudientes> Acudientes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Calificación> Calificaciones { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Periodos> Periodos { get; set; }
        public DbSet<Boletines> Boletines { get; set; }

        // Configuración opcional de relaciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Usuario → Rol (muchos a uno)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey("IdRol");

            // Relación Usuario → Curso (muchos a uno)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Curso)
                .WithMany(c => c.Estudiantes)
                .HasForeignKey("IdCurso");

            // Relación Curso → Asignaturas (uno a muchos)
            modelBuilder.Entity<Asignatura>()
                .HasOne(a => a.Curso)
                .WithMany(c => c.Asignaturas)
                .HasForeignKey("IdCurso");

            // Relación Curso → Horarios (uno a muchos)
            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Curso)
                .WithMany(c => c.Horarios)
                .HasForeignKey("IdCurso");

            // Relación Usuario → Calificaciones (uno a muchos)
            modelBuilder.Entity<Calificación>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Calificaciones)
                .HasForeignKey("IdUsuario");

            // Relación Usuario → Mensajes (uno a muchos)
            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.Remitente)
                .WithMany()
                .HasForeignKey("IdUsuario");

            // Relación Usuario → Reportes (uno a muchos)
            modelBuilder.Entity<Reporte>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey("IdUsuario");

            // Relación Curso → Actividades (uno a muchos)
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Curso)
                .WithMany()
                .HasForeignKey("IdCurso");
        }
    }
}
