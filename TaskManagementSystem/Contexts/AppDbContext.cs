using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ManagedTask>().HasMany(mt=> mt.Categories).WithMany(c=>c.Tasks);
            modelBuilder.Entity<ManagedTask>().HasOne(mt => mt.Priority).WithMany();
        }
        public DbSet<Category> categories { get; set; } = null!;
        public DbSet<ManagedTask> tasks { get; set; } = null!;
        public DbSet<PriorityLevel> priorityLevels { get; set; } = null!;
    }
}
