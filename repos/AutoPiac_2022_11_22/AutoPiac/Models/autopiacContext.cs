using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AutoPiac.Models
{
    public partial class autopiacContext : DbContext
    {
        public autopiacContext()
        {
        }

        public autopiacContext(DbContextOptions<autopiacContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Felhasznalo> Felhasznalos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=autopiac;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Felhasznalo>(entity =>
            {
                entity.ToTable("felhasznalo");

                entity.HasIndex(e => e.Email, "Email")
                    .IsUnique();

                entity.HasIndex(e => e.FelhasznaloNeve, "FelhasznaloNeve")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(7)")
                    .HasColumnName("ID");

                entity.Property(e => e.Aktiv).HasColumnType("int(1)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.FelhasznaloNeve)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Jogusultsag).HasColumnType("int(1)");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.TeljesNev)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
