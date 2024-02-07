using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserIBTerminal.Models;

public partial class Session4Context : DbContext
{
    public Session4Context()
    {
    }

    public Session4Context(DbContextOptions<Session4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=Session_4;User=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Posts", "Session_4");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Types", "Session_4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Users", "Session_4");

            entity.HasIndex(e => e.PostId, "User_FK");

            entity.HasIndex(e => e.TypeId, "Users_FK");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patryonomic).HasMaxLength(100);
            entity.Property(e => e.PostId).HasColumnName("Post_id");
            entity.Property(e => e.SecretWord)
                .HasMaxLength(50)
                .HasColumnName("Secret_word");
            entity.Property(e => e.Sex).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.True).HasDefaultValueSql("'0'");
            entity.Property(e => e.TypeId).HasColumnName("Type_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Users)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("Users_FK_1");

            entity.HasOne(d => d.Type).WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("Users_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
