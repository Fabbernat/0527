using Fabian_Bernat_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Fabian_Bernat_backend.Data;

public class ViragboltContext : DbContext
{
    public ViragboltContext(DbContextOptions<ViragboltContext> options)
        : base(options)
    {
    }

    public DbSet<Kategoria> Kategoriak => Set<Kategoria>();
    public DbSet<Aru> Aruk => Set<Aru>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategoria>(entity =>
        {
            entity.ToTable("kategoriak");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev).HasColumnName("nev").IsRequired();
        });

        modelBuilder.Entity<Aru>(entity =>
        {
            entity.ToTable("aruk");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev).HasColumnName("nev").IsRequired();
            entity.Property(e => e.Leiras).HasColumnName("leiras");
            entity.Property(e => e.Keszlet).HasColumnName("keszlet");
            entity.Property(e => e.Ar).HasColumnName("ar");
            entity.Property(e => e.KepUrl).HasColumnName("kepUrl");
            entity.Property(e => e.KategoriaId).HasColumnName("kategoriaId");

            entity.HasOne(e => e.Kategoria)
                .WithMany(k => k.Aruk)
                .HasForeignKey(e => e.KategoriaId);
        });
    }
}