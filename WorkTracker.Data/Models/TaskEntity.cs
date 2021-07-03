using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTracker.Utility.Enums;

namespace WorkTracker.Data.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public int ProjectId { get; set; }

        public int? Priority { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public ProjectEntity Project { get; set; }
    }

    public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TaskName)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(x => x.TaskDescription)
                .HasMaxLength(1000);
            builder.Property(x => x.Priority);
            builder.Property(x => x.TaskStatus)
                .HasConversion<int>();

            builder.HasOne<ProjectEntity>(x => x.Project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}