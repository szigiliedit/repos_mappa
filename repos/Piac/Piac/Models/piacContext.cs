using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Piac.Models
{
    public partial class piacContext : DbContext
    {
        public piacContext()
        {
        }

        public piacContext(DbContextOptions<piacContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gyumolcsok> Gyumolcsoks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=piac;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gyumolcsok>(entity =>
            {
                entity.ToTable("gyumolcsok");

                entity.HasIndex(e => e.Nev, "nev")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(5)");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(7)")
                    .HasColumnName("ar");

                entity.Property(e => e.KepUtvonala)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("kepUtvonala");

                entity.Property(e => e.Minoseg)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("minoseg");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nev");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
