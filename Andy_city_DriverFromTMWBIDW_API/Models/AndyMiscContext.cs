using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Andy_city_DriverFromTMWBIDW_API.Models;

public partial class AndyMiscContext : DbContext
{
    public AndyMiscContext()
    {
    }

    public AndyMiscContext(DbContextOptions<AndyMiscContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AndyCityDriverWorkingHoursRecord> AndyCityDriverWorkingHoursRecords { get; set; }

    public virtual DbSet<AndyDriverWorkbookRecordV1> AndyDriverWorkbookRecordV1s { get; set; }

    public virtual DbSet<AndyIsaacApiActivity> AndyIsaacApiActivities { get; set; }

    public virtual DbSet<AndyIsaacDrivernoDriverMapping> AndyIsaacDrivernoDriverMappings { get; set; }

    public virtual DbSet<AndyPayPeriodTable> AndyPayPeriodTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AT-TMW-BI-DW\\TMW;Initial Catalog=ANDY_MISC;user=ANDYDOTNET; password=The5Wire!Hasslid ;Trusted_Connection=False;TrustServerCertificate=True;Persist Security Info=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ANDYDOTNET");

        modelBuilder.Entity<AndyCityDriverWorkingHoursRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Andy_Cit__3214EC276D915682");

            entity.ToTable("Andy_City_Driver_WorkingHours_Record", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddDate).HasColumnType("datetime");
            entity.Property(e => e.AddedBy).IsUnicode(false);
            entity.Property(e => e.Division).IsUnicode(false);
            entity.Property(e => e.DriverId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DriverID");
            entity.Property(e => e.Km)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KM");
            entity.Property(e => e.LegNumber).IsUnicode(false);
            entity.Property(e => e.MoveNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderNumberTmw)
                .IsUnicode(false)
                .HasColumnName("OrderNumber_Tmw");
            entity.Property(e => e.Tractor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Trailer)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AndyDriverWorkbookRecordV1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ANDY_DRI__3213E83FA68F4708");

            entity.ToTable("ANDY_DRIVER_WORKBOOK_RECORD_V1", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityCodeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("activityCodeName");
            entity.Property(e => e.ActivityDate)
                .HasColumnType("datetime")
                .HasColumnName("activityDate");
            entity.Property(e => e.AddressCountry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address_country");
            entity.Property(e => e.AddressLatitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("address_latitude");
            entity.Property(e => e.AddressLongitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("address_longitude");
            entity.Property(e => e.AddressPostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("address_postalCode");
            entity.Property(e => e.Dateonly).HasColumnName("dateonly");
            entity.Property(e => e.DriverNo).HasColumnName("driverNo");
            entity.Property(e => e.FirstPage)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Form)
                .IsUnicode(false)
                .HasColumnName("form");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Maxid).HasColumnName("maxid");
            entity.Property(e => e.Miles)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("miles");
            entity.Property(e => e.MppId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mpp_id");
            entity.Property(e => e.MppLastfirst)
                .IsUnicode(false)
                .HasColumnName("mpp_lastfirst");
            entity.Property(e => e.Myrow)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("myrow");
            entity.Property(e => e.Myrow2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("myrow2");
            entity.Property(e => e.Mysecond)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mysecond");
            entity.Property(e => e.Mysecond2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mysecond2");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.NoteDriver1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note_driver1");
            entity.Property(e => e.NoteDriver2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note_driver2");
            entity.Property(e => e.NoteMovenum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note_movenum");
            entity.Property(e => e.NoteOrdernum).HasColumnName("note_ordernum");
            entity.Property(e => e.NoteTractor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note_tractor");
            entity.Property(e => e.NoteTrailer1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note_trailer1");
            entity.Property(e => e.NoteTrailer2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note_trailer2");
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.OdometerKm)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("odometerKm");
            entity.Property(e => e.OrdRevtype2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ord_revtype2");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.TotalHrs)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TripId).HasColumnName("tripId");
            entity.Property(e => e.TripNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tripNo");
            entity.Property(e => e.TrlFleet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("trl_fleet");
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vehicleno");
            entity.Property(e => e.ZoneName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZoneType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AndyIsaacApiActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ANDY_ISA__3213E83F27F9EF3B");

            entity.ToTable("ANDY_ISAAC_API_ACTIVITIES", "dbo");

            entity.HasIndex(e => e.ActivityDate, "ANDY_ISAAC_API_ACTIVITIES_INDEX_ACTIVITYDATE");

            entity.HasIndex(e => e.ActivityRecordId, "ANDY_activityRecordId_index");

            entity.HasIndex(e => e.TripId, "NonClusteredIndex-20230710-172010");

            entity.HasIndex(e => e.DriverNo, "dk_driverNo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityCode).HasColumnName("activityCode");
            entity.Property(e => e.ActivityCodeName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("activityCodeName");
            entity.Property(e => e.ActivityDate)
                .HasColumnType("datetime")
                .HasColumnName("activityDate");
            entity.Property(e => e.ActivityDutyType).HasColumnName("activityDutyType");
            entity.Property(e => e.ActivityId).HasColumnName("activityId");
            entity.Property(e => e.ActivityRecordId)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("activityRecordId");
            entity.Property(e => e.AddressCity)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("address_city");
            entity.Property(e => e.AddressCountry)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("address_country");
            entity.Property(e => e.AddressDistrict)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("address_district");
            entity.Property(e => e.AddressLatitude)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("address_latitude");
            entity.Property(e => e.AddressLongitude)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("address_longitude");
            entity.Property(e => e.AddressName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("address_name");
            entity.Property(e => e.AddressPostalCode)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("address_postalCode");
            entity.Property(e => e.AddressStreet)
                .HasMaxLength(160)
                .IsUnicode(false)
                .HasColumnName("address_street");
            entity.Property(e => e.Calldate)
                .HasColumnType("datetime")
                .HasColumnName("calldate");
            entity.Property(e => e.DriverNo).HasColumnName("driverNo");
            entity.Property(e => e.EquipmentNameList).HasColumnName("equipmentNameList");
            entity.Property(e => e.Form).HasColumnName("form");
            entity.Property(e => e.OdometerKm)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("odometerKm");
            entity.Property(e => e.TripId)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("tripId");
            entity.Property(e => e.TripIdNote).HasColumnName("tripId_Note");
            entity.Property(e => e.VehicleNo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("vehicleNo");
            entity.Property(e => e.WorkflowActivityId)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("workflowActivityId");
        });

        modelBuilder.Entity<AndyIsaacDrivernoDriverMapping>(entity =>
        {
            entity.HasKey(e => e.Driverno).HasName("PK__andy_isa__F15221F142C0D042");

            entity.ToTable("andy_isaac_driverno_driver_mapping", "dbo");

            entity.Property(e => e.Driverno)
                .ValueGeneratedNever()
                .HasColumnName("driverno");
            entity.Property(e => e.DriverFname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("driver_fname");
            entity.Property(e => e.DriverLname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("driver_lname");
            entity.Property(e => e.Driverid)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("driverid");
            entity.Property(e => e.Drivertype).HasColumnName("drivertype");
            entity.Property(e => e.Eld)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("eld");
            entity.Property(e => e.InsertDate)
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
        });

        modelBuilder.Entity<AndyPayPeriodTable>(entity =>
        {
            entity.HasKey(e => e.PayPeriodId).HasName("PK__Andy_Pay__66B8DF9EE88918A1");

            entity.ToTable("Andy_PayPeriodTable", "dbo");

            entity.Property(e => e.PayPeriodId).HasColumnName("PayPeriodID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PayPeriodPayDate).HasColumnName("PayPeriod_PayDate");
            entity.Property(e => e.WeekEndDate).HasColumnName("Week_EndDate");
            entity.Property(e => e.WeekStartDate).HasColumnName("Week_StartDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
