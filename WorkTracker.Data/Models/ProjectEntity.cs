using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WorkTracker.Utility.Enums;

namespace WorkTracker.Data.Models
{
    public class ProjectEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public List<TaskEntity> Tasks { get; set; }
    }

    public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.StartDate)
                .HasColumnType("Date");
            builder.Property(x => x.EndDate)
                .HasColumnType("Date");
            builder.Property(x => x.ProjectStatus)
                .HasConversion<int>();
        }
    }
}
