using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RealEstate.DbMysqlModels;

public partial class RealestateContext : DbContext
{
    public RealestateContext()
    {
    }

    public RealestateContext(DbContextOptions<RealestateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Realestate> Realestates { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=realestate;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("categories")
                .HasCharSet("utf8")
                .UseCollation("utf8_hungarian_ci");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Realestate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("realestates")
                .HasCharSet("utf8")
                .UseCollation("utf8_hungarian_ci");

            entity.HasIndex(e => e.CategoryId, "FK_realestates_categoryId");

            entity.HasIndex(e => e.SellerId, "FK_realestates_sellerId");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Area)
                .HasColumnType("int(11)")
                .HasColumnName("area");
            entity.Property(e => e.CategoryId)
                .HasColumnType("bigint(20)")
                .HasColumnName("categoryId");
            entity.Property(e => e.CreateAt).HasColumnName("createAt");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Floors)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("floors");
            entity.Property(e => e.Freeofcharge).HasColumnName("freeofcharge");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Latlong)
                .HasMaxLength(50)
                .HasColumnName("latlong");
            entity.Property(e => e.Rooms)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("rooms");
            entity.Property(e => e.SellerId)
                .HasColumnType("bigint(20)")
                .HasColumnName("sellerId");

            entity.HasOne(d => d.Category).WithMany(p => p.Realestates)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_realestates_categoryId");

            entity.HasOne(d => d.Seller).WithMany(p => p.Realestates)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_realestates_sellerId");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sellers")
                .HasCharSet("utf8")
                .UseCollation("utf8_hungarian_ci");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
