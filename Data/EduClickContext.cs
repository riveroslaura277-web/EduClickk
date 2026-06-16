using Microsoft.EntityFrameworkCore;
using EduClick.Models;
using System.Threading;

namespace EduClick.Data
{
    public class EduClickContext : DbContext
    {
        public EduClickContext(DbContextOptions<EduClickContext> options)
            : base(options)
        {
        }

        // Tus tablas existentes
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Acudiente> Acudientes { get; set; }
        public DbSet<Rector> Rectores { get; set; }

    }
}

 