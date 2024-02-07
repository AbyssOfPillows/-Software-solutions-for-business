using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class KeeperBdContext : DbContext
{
    public KeeperBdContext()
    {
    }

    public KeeperBdContext(DbContextOptions<KeeperBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=KeeperBD;User=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Applications", "KeeperBD");

            entity.HasIndex(e => e.EmployeeId, "Purposes_FK");

            entity.HasIndex(e => e.GroupId, "Purposes_FK_1");

            entity.Property(e => e.DateOfVisit).HasColumnType("date");
            entity.Property(e => e.DesiredEndDate).HasColumnType("date");
            entity.Property(e => e.DesiredStartDate).HasColumnType("date");
            entity.Property(e => e.Purpose).HasMaxLength(100);

            entity.HasOne(d => d.Employee).WithMany(p => p.Applications)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Applications_FK_1");

            entity.HasOne(d => d.Group).WithMany(p => p.Applications)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Applications_FK");
        });

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Departaments", "KeeperBD");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity.ToTable("Employees", "KeeperBD");

            entity.HasIndex(e => e.DepartmentId, "Employes_FK");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employes_FK");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Groups", "KeeperBD");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("Group");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Visitors", "KeeperBD");

            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .HasColumnName("E-mail");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NumberPhone).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Photo).HasColumnType("blob");
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasMany(d => d.Groups).WithMany(p => p.Visitors)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupsVisitor",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("GroupsVisitors_FK"),
                    l => l.HasOne<Visitor>().WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("GroupsVisitors_FK_1"),
                    j =>
                    {
                        j.HasKey("VisitorId", "GroupId").HasName("PRIMARY");
                        j.ToTable("GroupsVisitors", "KeeperBD");
                        j.HasIndex(new[] { "VisitorId" }, "GroupsVisitors_FK");
                        j.HasIndex(new[] { "GroupId" }, "GroupsVisitors_FK_1");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
