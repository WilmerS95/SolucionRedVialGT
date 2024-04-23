using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RedVialGT.Server.Models;

public partial class DbredVialGuatemalaContext : DbContext
{
    public DbredVialGuatemalaContext()
    {
    }

    public DbredVialGuatemalaContext(DbContextOptions<DbredVialGuatemalaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433D7DA2A958");

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).ValueGeneratedNever();
            entity.Property(e => e.LugaresTuristicos)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NombreCabecera)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.IdRuta).HasName("PK__Rutas__887538FEA0F5C708");

            entity.Property(e => e.NombreRuta)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentoDestinoNavigation).WithMany(p => p.RutaIdDepartamentoDestinoNavigations)
                .HasForeignKey(d => d.IdDepartamentoDestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rutas__IdDeparta__4CA06362");

            entity.HasOne(d => d.IdDepartamentoPartidaNavigation).WithMany(p => p.RutaIdDepartamentoPartidaNavigations)
                .HasForeignKey(d => d.IdDepartamentoPartida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rutas__IdDeparta__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
