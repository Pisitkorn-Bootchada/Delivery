using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Korntest.Models.db;

public partial class TestdataContext : DbContext
{
    public TestdataContext()
    {
    }

    public TestdataContext(DbContextOptions<TestdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
     //   => optionsBuilder.UseSqlServer("Server=192.168.0.81;Database=Testdata;User Id=sa;Password=dogthaiP@ssw0rd;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.SdAutoId);

            entity.ToTable("Customer");

            entity.Property(e => e.SdAutoId).HasColumnName("SdAutoID");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrAutoId).HasColumnName("TrAutoID");
            entity.Property(e => e.TransportDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
