using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=Company;User=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Applications", "Company");

            entity.HasIndex(e => e.GroupId, "Users_FK");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Approved).HasColumnName("Approved?");
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.DepartureTime).HasMaxLength(100);
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .HasColumnName("E-mail");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.Organization).HasMaxLength(100);
            entity.Property(e => e.PasportDetails).HasMaxLength(50);
            entity.Property(e => e.PassportScan).HasColumnType("blob");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Photo).HasColumnType("blob");
            entity.Property(e => e.Reason).HasMaxLength(100);
            entity.Property(e => e.TheDesiredEndOfTheActionOfTheApplication).HasColumnType("date");
            entity.Property(e => e.TheDesiredStartOfTheActionOfTheApplication).HasColumnType("date");
            entity.Property(e => e.TypeApplication).HasMaxLength(100);
            entity.Property(e => e.Visited).HasColumnName("Visited?");

            entity.HasOne(d => d.Group).WithMany(p => p.Applications)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("Applications_FK");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Appointments", "Company");

            entity.HasIndex(e => e.EmployeId, "Appointments_FK");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateOfVisit).HasMaxLength(50);
            entity.Property(e => e.TimeOfVisit).HasMaxLength(100);

            entity.HasOne(d => d.Employe).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.EmployeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Appointments_FK");
        });

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Departaments", "Company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Departament1)
                .HasMaxLength(50)
                .HasColumnName("Departament");
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.EmployeeCode).HasName("PRIMARY");

            entity.ToTable("Employes", "Company");

            entity.HasIndex(e => e.Departament, "Employes_FK");

            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");

            entity.HasOne(d => d.DepartamentNavigation).WithMany(p => p.Employes)
                .HasForeignKey(d => d.Departament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employes_FK");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Groups", "Company");

            entity.HasIndex(e => e.Appointment, "Groups_FK");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupNumber).HasMaxLength(50);

            entity.HasOne(d => d.AppointmentNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Appointment)
                .HasConstraintName("Groups_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
