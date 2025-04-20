using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace praktika12345.Models;

public partial class Praktos123Context : DbContext
{
    public Praktos123Context()
    {
    }

    public Praktos123Context(DbContextOptions<Praktos123Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Squad> Squads { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = localhost; Database=praktos123; User = sa; Password = sa; Encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D160BF716DAAB4");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Capital).HasMaxLength(100);
            entity.Property(e => e.Continent).HasMaxLength(100);
            entity.Property(e => e.CountryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B938558BE76C1C13");

            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.LanguageGroup).HasMaxLength(50);
            entity.Property(e => e.LanguageName).HasMaxLength(100);
            entity.Property(e => e.LanguageSystem).HasMaxLength(50);
        });

        modelBuilder.Entity<Squad>(entity =>
        {
            entity.HasKey(e => e.SquadsId).HasName("PK__Squads__FD2B381E125B1512");

            entity.Property(e => e.SquadsId).HasColumnName("SquadsID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

            entity.HasOne(d => d.Country).WithMany(p => p.Squads)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Squads__CountryI__3B75D760");

            entity.HasOne(d => d.Language).WithMany(p => p.Squads)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__Squads__Language__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__Users__A349B04268233E1E");

            entity.Property(e => e.UsersId).HasColumnName("UsersID");
            entity.Property(e => e.UserLogin).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
            entity.Property(e => e.UserRole).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
