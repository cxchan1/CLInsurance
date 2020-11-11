using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class NudeDBContext : DbContext
    {
        public NudeDBContext(DbContextOptions<NudeDBContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
