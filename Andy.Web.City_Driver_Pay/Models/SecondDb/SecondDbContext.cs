using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Andy.Web.City_Driver_Pay.Models.SecondDb;

public partial class SecondDbContext : DbContext
{
    public SecondDbContext()
    {
    }

    public SecondDbContext(DbContextOptions<SecondDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AndyCityDriverWorkingHoursRecord> AndyCityDriverWorkingHoursRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AT-TMW-BI-DW\\TMW;Initial Catalog=ANDY_MISC;user=ANDYDOTNET; password=The5Wire!Hasslid ;Trusted_Connection=False;TrustServerCertificate=True;Persist Security Info=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ANDYDOTNET");

        modelBuilder.Entity<AndyCityDriverWorkingHoursRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Andy_City_Driver_WorkingHours_Record", "dbo");

            entity.Property(e => e.AddDate).HasColumnType("datetime");
            entity.Property(e => e.AddedBy).IsUnicode(false);
            entity.Property(e => e.CalculateHours).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Division)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DriverId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DriverID");
            entity.Property(e => e.LegNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MoveNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderNumberTmw)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OrderNumber_Tmw");
            entity.Property(e => e.PaidHours).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PayRate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPay).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tractor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Trailer)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
