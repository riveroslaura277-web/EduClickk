using Microsoft.EntityFrameworkCore;
using EduClick.Models;

namespace EduClick.Data
{
    public class EduClickContext : DbContext
    {
        public EduClickContext(DbContextOptions<EduClickContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<Acudientes> Acudientes { get; set; }
        public DbSet<Rector> Rectores { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }
    public DbSet<Estudiantes> Estudiante { get; set; } // si existe el modelo
        public DbSet<DetalleEstudiante> DetalleEstudiantes { get; set; }
    }
    }
