using Microsoft.EntityFrameworkCore;
using WorkTracker.Data.Models;

namespace WorkTracker.Data.Infrastructure
{
    public class WorkDbContext : DbContext
    {
        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options)
        {
        }

        public DbSet<TaskEntity> TaskEntities { get; set; }

        public DbSet<ProjectEntity> ProjectEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>().ToTable("Tasks");
            modelBuilder.Entity<ProjectEntity>().ToTable("Projects");

            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
        }
    }
}
