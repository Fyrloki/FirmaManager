using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FirmaManager.EntityFrameworkData.Models
{
    public partial class DieFirmaContext : DbContext
    {
        public DieFirmaContext()
        {
        }

        public DieFirmaContext(DbContextOptions<DieFirmaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbPerson> TbPeople { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbPerson>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__tb_Perso__C5B19602CD3F84A1");

                entity.ToTable("tb_Person");

                entity.HasIndex(e => e.PersonNummer, "UQ__tb_Perso__866B88FBBD70C612")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("UID");

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PersonNummer)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
