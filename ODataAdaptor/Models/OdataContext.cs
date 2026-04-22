using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ODataAdaptor.Models;

public partial class OdataContext : DbContext
{
    public OdataContext()
    {
    }

    public OdataContext(DbContextOptions<OdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskDatum> TaskData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskDatum>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK_TaskData");

            entity.ToTable("taskData");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("TaskID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");           
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
