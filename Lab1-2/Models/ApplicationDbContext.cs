using Microsoft.EntityFrameworkCore;

namespace Lab1_2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BlogItem> BlogItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}