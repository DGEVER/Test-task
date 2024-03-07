using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test_task.Models;

public partial class TestTaskContext : DbContext
{
    public TestTaskContext()
    {
    }

    public TestTaskContext(DbContextOptions<TestTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PaintworkMaterial> PaintworkMaterials { get; set; }
    //TODO: Поменять на строку из файла конфигурации
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-T1HQMAS;Database=Test_task;Trusted_Connection=True;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaintworkMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paintwor__3214EC27612EF5CE");

            entity.ToTable("Paintwork_material");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContainerVolume).HasColumnName("Container_volume");
            entity.Property(e => e.ItemNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Item_number");
            entity.Property(e => e.NameMaterial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_material");
            entity.Property(e => e.SpecificWeight).HasColumnName("Specific_weight");
            entity.Property(e => e.TypeMaterial)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Type_material");
            entity.Property(e => e.WeightWithMaterial).HasColumnName("Weight_with_material");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
