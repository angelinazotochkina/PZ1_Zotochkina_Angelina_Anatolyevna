using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PZ1_Zotochkina_Angelina_Anatolyevna.Models
{
    public partial class PZ1_Zotochkina_Angelina_AnatolyevnaContext : DbContext
    {
        public PZ1_Zotochkina_Angelina_AnatolyevnaContext()
        {
        }

        public PZ1_Zotochkina_Angelina_AnatolyevnaContext(DbContextOptions<PZ1_Zotochkina_Angelina_AnatolyevnaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; } = null!;
        public virtual DbSet<UsersDetail> UsersDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-JQUVBIP;Database=PZ1_Zotochkina_Angelina_Anatolyevna;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UsersDetail>(entity =>
            {
                entity.ToTable("UsersDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersFetails)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersDetail_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
