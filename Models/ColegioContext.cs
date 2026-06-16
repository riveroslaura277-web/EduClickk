using Microsoft.EntityFrameworkCore;

namespace EduClick.Models
{
    public class ColegioContext : DbContext
    {
        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }

    }
}
