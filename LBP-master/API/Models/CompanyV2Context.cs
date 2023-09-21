using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class CompanyV2Context : DbContext
{
    public CompanyV2Context()
    {
    }

    public CompanyV2Context(DbContextOptions<CompanyV2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=CompanyV.2;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ToWhomId, "Appointments_FK");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateOfVisit).HasMaxLength(50);
            entity.Property(e => e.ToWhomId).HasColumnName("ToWhom(ID)");

            entity.HasOne(d => d.ToWhom).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ToWhomId)
                .HasConstraintName("Appointments_FK");
        });

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Departament1)
                .HasMaxLength(50)
                .HasColumnName("Departament");
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.EmployeeCode).HasName("PRIMARY");

            entity.HasIndex(e => e.Departament, "Employes_FK");

            entity.Property(e => e.EmployeeCode).ValueGeneratedNever();
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");

            entity.HasOne(d => d.DepartamentNavigation).WithMany(p => p.Employes)
                .HasForeignKey(d => d.Departament)
                .HasConstraintName("Employes_FK");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Appointment, "Groups_FK");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GroupNumber).HasMaxLength(50);

            entity.HasOne(d => d.AppointmentNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Appointment)
                .HasConstraintName("Groups_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Appointment, "Users_FK");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .HasColumnName("E-mail");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.PasportDetails).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);

            entity.HasOne(d => d.AppointmentNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Appointment)
                .HasConstraintName("Users_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
