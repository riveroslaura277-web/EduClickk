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
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Acudiente> Acudientes { get; set; }
        public DbSet<Rector> Rectores { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<PeriodoViewModel> Periodos { get; set; }
        public DbSet<CursoViewModel> Cursos { get; set; }
        public DbSet<MateriaViewModel> Materias { get; set; }
    }
}
