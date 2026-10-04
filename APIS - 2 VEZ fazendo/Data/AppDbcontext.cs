using System;
using System.Collections.Generic;
using APIS___2_VEZ_fazendo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIS___2_VEZ_fazendo.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F83478BFB");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Serie).HasColumnName("serie");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
