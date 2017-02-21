using Microsoft.EntityFrameworkCore;

namespace Wholesaler.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Fruit> Fruits { get; set; }

    }
}
