using Microsoft.EntityFrameworkCore;
using Assessment9.Models;

namespace Assessment9.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students => Set<Student>();
    }
}
