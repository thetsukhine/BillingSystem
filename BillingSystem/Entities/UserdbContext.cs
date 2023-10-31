﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Entities;

public partial class UserdbContext : DbContext
{
    public UserdbContext()
    {
    }

    public UserdbContext(DbContextOptions<UserdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public DbSet<Bill> Bill  { get; set; }

    public DbSet<Pay> Pay { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=superrich;database=userdb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.LastName).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Username).HasMaxLength(45);
            //entity.Property(e => e.PasswordSalt).HasMaxLength(45);
            //entity.Property( e => e.PrimaryEmail ).HasMaxLength(45);
            //entity.Property(e => e.SecondaryEmail).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
