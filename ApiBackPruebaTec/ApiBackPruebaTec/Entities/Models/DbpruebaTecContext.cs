using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiBackPruebaTec.Entities.Models;

public partial class DbpruebaTecContext : DbContext
{
    public DbpruebaTecContext()
    {
    }

    public DbpruebaTecContext(DbContextOptions<DbpruebaTecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC07F2CF998E");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(75)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0774882704");

            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
