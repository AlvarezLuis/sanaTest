using Microsoft.EntityFrameworkCore;
using sanaTest.Models;

namespace sanaTest.Data
{
    public class SanaContext : DbContext
    {
        public SanaContext(DbContextOptions<SanaContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("product").HasKey("Id");
        }
    }
}
