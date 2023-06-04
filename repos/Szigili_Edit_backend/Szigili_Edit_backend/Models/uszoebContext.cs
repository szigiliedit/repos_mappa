using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Szigili_Edit_backend.Models
{
    public partial class uszoebContext : DbContext
    {
        public uszoebContext()
        {
        }

        public uszoebContext(DbContextOptions<uszoebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orszagok> Orszagoks { get; set; } = null!;
        public virtual DbSet<Szamok> Szamoks { get; set; } = null!;
        public virtual DbSet<Versenyzok> Versenyzoks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=uszoeb;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orszagok>(entity =>
            {
                entity.ToTable("orszagok");

                entity.HasIndex(e => e.Nobid, "nobid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nev)
                    .HasMaxLength(60)
                    .HasColumnName("nev");

                entity.Property(e => e.Nobid)
                    .HasMaxLength(3)
                    .HasColumnName("nobid");
            });

            modelBuilder.Entity<Szamok>(entity =>
            {
                entity.ToTable("szamok");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nev)
                    .HasMaxLength(40)
                    .HasColumnName("nev");

                entity.Property(e => e.Versenyzoid)
                    .HasColumnType("int(11)")
                    .HasColumnName("versenyzoid");

                entity.HasOne(d => d.Versenyzo)
                    .WithMany(p => p.Szamoks)
                    .HasForeignKey(d => d.Versenyzoid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("szamok_ibfk_1");
            });

            modelBuilder.Entity<Versenyzok>(entity =>
            {
                entity.ToTable("versenyzok");

                entity.HasIndex(e => e.Nev, "nev")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nem)
                    .HasColumnType("text")
                    .HasColumnName("nem");

                entity.Property(e => e.Nev)
                    .HasMaxLength(60)
                    .HasColumnName("nev");

                entity.Property(e => e.OrszagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("orszagId");

                entity.HasOne(d => d.Orszag)
                    .WithMany(p => p.Versenyzoks)
                    .HasForeignKey(d => d.OrszagId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("versenyzok_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
