using AnimalManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalManager.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Animal> Animal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Animal>().Property(a => a.Species).IsRequired().HasMaxLength(100);
            
        }
    }
}