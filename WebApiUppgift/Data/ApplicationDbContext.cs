using Microsoft.EntityFrameworkCore;

namespace WebApiUppgift.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Annonser> Annonser { get; set; }
    }
}
