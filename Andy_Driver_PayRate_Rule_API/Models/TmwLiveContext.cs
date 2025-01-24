using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Andy_Driver_PayRate_Rule_API.Models;

public partial class TmwLiveContext : DbContext
{
    public TmwLiveContext()
    {
    }

    public TmwLiveContext(DbContextOptions<TmwLiveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AndyDriverPayDetail> AndyDriverPayDetails { get; set; }

    public virtual DbSet<AndyDriverPayRate> AndyDriverPayRates { get; set; }

    public virtual DbSet<AndyDriverPayRuleOverTime> AndyDriverPayRuleOverTimes { get; set; }

    public virtual DbSet<AndyDriverRateFleetCompany> AndyDriverRateFleetCompanies { get; set; }

    public virtual DbSet<Labelfile> Labelfiles { get; set; }

    public virtual DbSet<Manpowerprofile> Manpowerprofiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AT-TMW-SQL\\TMW;Initial Catalog=TMW_Live;user=AndyWebDev; password=The5Wire!Hasslid ;Trusted_Connection=False;TrustServerCertificate=True;Persist Security Info=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AndyDriverPayDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Andy_Driver_PayDetail");

            entity.Property(e => e.DriverFname)
                .IsUnicode(false)
                .HasColumnName("DriverFName");
            entity.Property(e => e.DriverId).IsUnicode(false);
            entity.Property(e => e.DriverLastPay).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DriverLname)
                .IsUnicode(false)
                .HasColumnName("DriverLName");
            entity.Property(e => e.DriverMname)
                .IsUnicode(false)
                .HasColumnName("DriverMName");
            entity.Property(e => e.DriverPayTo).IsUnicode(false);
            entity.Property(e => e.TeamLeader)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AndyDriverPayRate>(entity =>
        {
            entity.HasKey(e => e.AndyDriverPayRateId).HasName("PK__Andy_Dri__4E6B5F2AA6B70151");

            entity.ToTable("Andy_Driver_PayRate");

            entity.Property(e => e.AndyDriverPayRateId).HasColumnName("Andy_Driver_PayRateId");
            entity.Property(e => e.DriverId)
                .IsUnicode(false)
                .HasColumnName("DriverID");
            entity.Property(e => e.DriverTyper)
                .IsUnicode(false)
                .HasColumnName("Driver_Typer");
            entity.Property(e => e.EffectiveDateFrom).HasColumnName("Effective_Date_From");
            entity.Property(e => e.EffectiveDateTo).HasColumnName("Effective_Date_To");
            entity.Property(e => e.FleetCompanyId)
                .IsUnicode(false)
                .HasColumnName("Fleet_Company_ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.OverTimeRateDayShift).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OverTimeRateEveShift)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("OverTimeRateEve_Shift");
            entity.Property(e => e.OverTimeRateNightShift).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OverTimeRateWeekendShift).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RatePerMileage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Rate_Per_Mileage");
            entity.Property(e => e.RegularRateDayShift).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RegularRateEveShift)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("RegularRateEve_Shift");
            entity.Property(e => e.RegularRateNightShift).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdateBy)
                .IsUnicode(false)
                .HasColumnName("Update_By");
            entity.Property(e => e.WeekendRate).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<AndyDriverPayRuleOverTime>(entity =>
        {
            entity.HasKey(e => e.PayRateName).HasName("PK_AndyDriverPayRuleOverTime");

            entity.ToTable("Andy_DriverPay_Rule_OverTime");

            entity.Property(e => e.PayRateName)
                .HasMaxLength(255)
                .HasColumnName("Pay_Rate_Name");
            entity.Property(e => e.Formula).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PayRateForumula)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AndyDriverRateFleetCompany>(entity =>
        {
            entity.HasKey(e => e.FleetCompanyId1).HasName("PK__Andy_Dri__6C56152CA66DD152");

            entity.ToTable("Andy_DriverRate_Fleet_Company");

            entity.Property(e => e.FleetCompanyId1).HasColumnName("FleetCompanyId");
            entity.Property(e => e.FleetCompanyId)
                .IsUnicode(false)
                .HasColumnName("Fleet_Company_ID");
            entity.Property(e => e.FleetCompanyLabel)
                .IsUnicode(false)
                .HasColumnName("Fleet_Company_Label");
            entity.Property(e => e.FleetName).IsUnicode(false);
            entity.Property(e => e.FleetRegularRate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Fleet_RegularRate");
        });

        modelBuilder.Entity<Labelfile>(entity =>
        {
            entity.HasKey(e => new { e.Labeldefinition, e.Abbr }).HasName("pkey_label");

            entity.ToTable("labelfile", tb =>
                {
                    tb.HasTrigger("dt_labelfile");
                    tb.HasTrigger("dt_labelfile_rowsec");
                    tb.HasTrigger("it_labelfile");
                    tb.HasTrigger("iut_labelfile_freightordervalidation");
                    tb.HasTrigger("iut_labelfile_rowsec");
                    tb.HasTrigger("ut_labelfile");
                });

            entity.HasIndex(e => e.Abbr, "dk_abbr");

            entity.HasIndex(e => e.Timestamp, "idx_labelfile_timestamp").HasFillFactor(90);

            entity.Property(e => e.Labeldefinition)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("labeldefinition");
            entity.Property(e => e.Abbr)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("abbr");
            entity.Property(e => e.AcctDb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("acct_db");
            entity.Property(e => e.AcctServer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("acct_server");
            entity.Property(e => e.AutoComplete)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("auto_complete");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreateMove)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("create_move");
            entity.Property(e => e.Edicode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("edicode");
            entity.Property(e => e.ExcludeFromCreditcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exclude_from_creditcheck");
            entity.Property(e => e.GlobalLabel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("Y")
                .IsFixedLength()
                .HasColumnName("global_label");
            entity.Property(e => e.IcClearGlnum)
                .HasMaxLength(66)
                .IsUnicode(false)
                .HasColumnName("ic_clear_glnum");
            entity.Property(e => e.InventoryItem)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .HasColumnName("inventory_item");
            entity.Property(e => e.LabelExtrastring1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring1");
            entity.Property(e => e.LabelExtrastring1Label)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring1_label");
            entity.Property(e => e.LabelExtrastring2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring2");
            entity.Property(e => e.LabelExtrastring2Label)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring2_label");
            entity.Property(e => e.LabelExtrastring3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring3");
            entity.Property(e => e.LabelExtrastring4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring4");
            entity.Property(e => e.LabelExtrastring5)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring5");
            entity.Property(e => e.LabelExtrastring6)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("label_extrastring6");
            entity.Property(e => e.Locked)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("locked");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Param1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("param1");
            entity.Property(e => e.Param1Label)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("param1_label");
            entity.Property(e => e.Param2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("param2");
            entity.Property(e => e.Param2Label)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("param2_label");
            entity.Property(e => e.PytItemcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyt_itemcode");
            entity.Property(e => e.Retired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("retired");
            entity.Property(e => e.Systemcode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("systemcode");
            entity.Property(e => e.TeamleaderEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("teamleader_email");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.Userlabelname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userlabelname");
        });

        modelBuilder.Entity<Manpowerprofile>(entity =>
        {
            entity.HasKey(e => e.MppId).HasName("u_mpp_id");

            entity.ToTable("manpowerprofile", tb =>
                {
                    tb.HasTrigger("dt_manpowerprofile");
                    tb.HasTrigger("iud_manpowerprofile_audit");
                    tb.HasTrigger("iut_manpower_changelog");
                    tb.HasTrigger("iut_manpowerprofile_rowsec");
                    tb.HasTrigger("iut_manpowerprofile_setschedule");
                    tb.HasTrigger("manpower_revtypes");
                });

            entity.HasIndex(e => e.MppOtherid, "d_mpp_otherid");

            entity.HasIndex(e => e.MppLastfirst, "dk_lastfirst");

            entity.HasIndex(e => e.MppStatus, "dk_manpowerprofile_mpp_status");

            entity.HasIndex(e => e.Timestamp, "idx_manpowerprofile_timestamp").HasFillFactor(90);

            entity.Property(e => e.MppId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_id");
            entity.Property(e => e.CompensationType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.GuaranteedPayPromised)
                .HasColumnType("money")
                .HasColumnName("guaranteed_pay_promised");
            entity.Property(e => e.Mpp90daystart)
                .HasColumnType("datetime")
                .HasColumnName("mpp_90daystart");
            entity.Property(e => e.MppAceid)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mpp_aceid");
            entity.Property(e => e.MppAceidtype)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_aceidtype");
            entity.Property(e => e.MppActgType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength()
                .HasColumnName("mpp_actg_type");
            entity.Property(e => e.MppAddress1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mpp_address1");
            entity.Property(e => e.MppAddress2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mpp_address2");
            entity.Property(e => e.MppAdvanceRateSolo)
                .HasColumnType("money")
                .HasColumnName("mpp_advance_rate_solo");
            entity.Property(e => e.MppAdvanceRateTeam)
                .HasColumnType("money")
                .HasColumnName("mpp_advance_rate_team");
            entity.Property(e => e.MppAlternatephone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mpp_alternatephone");
            entity.Property(e => e.MppArvDepAllowanceMins).HasColumnName("mpp_ArvDep_Allowance_mins");
            entity.Property(e => e.MppAthomeTerminal)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_athome_terminal");
            entity.Property(e => e.MppAvghourlypay)
                .HasColumnType("money")
                .HasColumnName("mpp_avghourlypay");
            entity.Property(e => e.MppAvgperiodpay)
                .HasColumnType("money")
                .HasColumnName("mpp_avgperiodpay");
            entity.Property(e => e.MppAvlCity)
                .HasDefaultValue(0)
                .HasColumnName("mpp_avl_city");
            entity.Property(e => e.MppAvlCmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("mpp_avl_cmp_id");
            entity.Property(e => e.MppAvlDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("mpp_avl_date");
            entity.Property(e => e.MppAvlLgh)
                .HasDefaultValue(0)
                .HasColumnName("mpp_avl_lgh");
            entity.Property(e => e.MppAvlStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_avl_status");
            entity.Property(e => e.MppBidNextHours)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("mpp_bid_next_hours");
            entity.Property(e => e.MppBidNextRoutestore)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_bid_next_routestore");
            entity.Property(e => e.MppBidNextStarttime)
                .HasColumnType("datetime")
                .HasColumnName("mpp_bid_next_starttime");
            entity.Property(e => e.MppBidNextType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_bid_next_type");
            entity.Property(e => e.MppBmpPathname)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("mpp_bmp_pathname");
            entity.Property(e => e.MppBranch)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("mpp_branch");
            entity.Property(e => e.MppCarrier)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_carrier");
            entity.Property(e => e.MppCitizenshipCountry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mpp_citizenship_country");
            entity.Property(e => e.MppCitizenshipStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_citizenship_status");
            entity.Property(e => e.MppCity).HasColumnName("mpp_city");
            entity.Property(e => e.MppCmpissuedpoints).HasColumnName("mpp_cmpissuedpoints");
            entity.Property(e => e.MppComment1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mpp_comment1");
            entity.Property(e => e.MppCompany)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_company");
            entity.Property(e => e.MppComparisonflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_comparisonflag");
            entity.Property(e => e.MppContDedNbr).HasColumnName("mpp_cont_ded_nbr");
            entity.Property(e => e.MppContPeriod).HasColumnName("mpp_cont_period");
            entity.Property(e => e.MppContRemainBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_cont_remain_balance");
            entity.Property(e => e.MppContWeekAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_cont_week_amt");
            entity.Property(e => e.MppContributionAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_contribution_amt");
            entity.Property(e => e.MppCountry)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_country");
            entity.Property(e => e.MppCreatedate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("mpp_createdate");
            entity.Property(e => e.MppCsaScore).HasColumnName("mpp_csa_score");
            entity.Property(e => e.MppCurrency)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_currency");
            entity.Property(e => e.MppCurrentphone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mpp_currentphone");
            entity.Property(e => e.MppCyclicDspEnabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_cyclic_dsp_enabled");
            entity.Property(e => e.MppDailyguarenteedhours)
                .HasColumnType("money")
                .HasColumnName("mpp_dailyguarenteedhours");
            entity.Property(e => e.MppDailyhrsest).HasColumnName("mpp_dailyhrsest");
            entity.Property(e => e.MppDateofbirth)
                .HasColumnType("datetime")
                .HasColumnName("mpp_dateofbirth");
            entity.Property(e => e.MppDefaultShiftend)
                .HasColumnType("datetime")
                .HasColumnName("mpp_default_shiftend");
            entity.Property(e => e.MppDefaultShiftpriority)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_default_shiftpriority");
            entity.Property(e => e.MppDefaultShiftstart)
                .HasColumnType("datetime")
                .HasColumnName("mpp_default_shiftstart");
            entity.Property(e => e.MppDivision)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_division");
            entity.Property(e => e.MppDomicile)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_domicile");
            entity.Property(e => e.MppDrivedate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_drivedate");
            entity.Property(e => e.MppDriverlogGroups)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mpp_driverlogGroups");
            entity.Property(e => e.MppDriverlogTerminal)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mpp_driverlogTerminal");
            entity.Property(e => e.MppDriverlogtype)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_driverlogtype");
            entity.Property(e => e.MppEffDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_eff_date");
            entity.Property(e => e.MppEligibleStartDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_eligible_start_date");
            entity.Property(e => e.MppEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mpp_email");
            entity.Property(e => e.MppEmername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("mpp_emername");
            entity.Property(e => e.MppEmerphone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mpp_emerphone");
            entity.Property(e => e.MppEmployedby)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("mpp_employedby");
            entity.Property(e => e.MppEmployeetype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_employeetype");
            entity.Property(e => e.MppEstlogDatetime)
                .HasColumnType("datetime")
                .HasColumnName("mpp_estlog_datetime");
            entity.Property(e => e.MppExp1Date)
                .HasColumnType("datetime")
                .HasColumnName("mpp_exp1_date");
            entity.Property(e => e.MppExp1Enddate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_exp1_enddate");
            entity.Property(e => e.MppExp2Date)
                .HasColumnType("datetime")
                .HasColumnName("mpp_exp2_date");
            entity.Property(e => e.MppExp2Enddate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_exp2_enddate");
            entity.Property(e => e.MppFirstname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("mpp_firstname");
            entity.Property(e => e.MppFleet)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_fleet");
            entity.Property(e => e.MppForgiveAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_forgive_amt");
            entity.Property(e => e.MppForgiveCrdNbr).HasColumnName("mpp_forgive_crd_nbr");
            entity.Property(e => e.MppForgivePeriod).HasColumnName("mpp_forgive_period");
            entity.Property(e => e.MppForgiveRemainBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_forgive_remain_balance");
            entity.Property(e => e.MppForgiveWeekCrdAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_forgive_week_crd_amt");
            entity.Property(e => e.MppFourteenhrest).HasColumnName("mpp_fourteenhrest");
            entity.Property(e => e.MppGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_gender");
            entity.Property(e => e.MppGpClass)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasDefaultValue("DEFAULT")
                .IsFixedLength()
                .HasColumnName("mpp_gp_class");
            entity.Property(e => e.MppGpsDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_gps_date");
            entity.Property(e => e.MppGpsDesc)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("mpp_gps_desc");
            entity.Property(e => e.MppGpsHeading).HasColumnName("mpp_gps_heading");
            entity.Property(e => e.MppGpsLatitude).HasColumnName("mpp_gps_latitude");
            entity.Property(e => e.MppGpsLongitude).HasColumnName("mpp_gps_longitude");
            entity.Property(e => e.MppGpsOdometer).HasColumnName("mpp_gps_odometer");
            entity.Property(e => e.MppGpsSpeed).HasColumnName("mpp_gps_speed");
            entity.Property(e => e.MppGrandfatherDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_grandfather_date");
            entity.Property(e => e.MppHiredate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_hiredate");
            entity.Property(e => e.MppHomeCity)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("mpp_home_city");
            entity.Property(e => e.MppHomeLatitude).HasColumnName("mpp_home_latitude");
            entity.Property(e => e.MppHomeLongitude).HasColumnName("mpp_home_longitude");
            entity.Property(e => e.MppHomephone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mpp_homephone");
            entity.Property(e => e.MppHosPollRequired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_hos_poll_required");
            entity.Property(e => e.MppHosactivityupdateon)
                .HasColumnType("datetime")
                .HasColumnName("mpp_hosactivityupdateon");
            entity.Property(e => e.MppHosstatus).HasColumnName("mpp_hosstatus");
            entity.Property(e => e.MppHosstatusdate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_hosstatusdate");
            entity.Property(e => e.MppHourlyrate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("mpp_hourlyrate");
            entity.Property(e => e.MppHours1).HasColumnName("mpp_hours1");
            entity.Property(e => e.MppHours1Week).HasColumnName("mpp_hours1_week");
            entity.Property(e => e.MppHours2).HasColumnName("mpp_hours2");
            entity.Property(e => e.MppHours3).HasColumnName("mpp_hours3");
            entity.Property(e => e.MppHrsDblTime)
                .HasColumnType("money")
                .HasColumnName("mpp_hrs_dbl_time");
            entity.Property(e => e.MppLastCalcdate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_last_calcdate");
            entity.Property(e => e.MppLastDailyLogsConfirmedDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_last_DailyLogsConfirmedDate");
            entity.Property(e => e.MppLastDailyLogsDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_last_DailyLogsDate");
            entity.Property(e => e.MppLastHome)
                .HasColumnType("datetime")
                .HasColumnName("mpp_last_home");
            entity.Property(e => e.MppLastLogDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_last_log_date");
            entity.Property(e => e.MppLastfirst)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("mpp_lastfirst");
            entity.Property(e => e.MppLastlogCmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_lastlog_cmp_id");
            entity.Property(e => e.MppLastlogCmpName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mpp_lastlog_cmp_name");
            entity.Property(e => e.MppLastlogEstdate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_lastlog_estdate");
            entity.Property(e => e.MppLastmobilecomm)
                .HasColumnType("datetime")
                .HasColumnName("mpp_lastmobilecomm");
            entity.Property(e => e.MppLastname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("mpp_lastname");
            entity.Property(e => e.MppLicenseclass)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mpp_licenseclass");
            entity.Property(e => e.MppLicensenumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("mpp_licensenumber");
            entity.Property(e => e.MppLicensestate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_licensestate");
            entity.Property(e => e.MppMcommId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mpp_mcommID");
            entity.Property(e => e.MppMcommType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_mcommType");
            entity.Property(e => e.MppMiddlename)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_middlename");
            entity.Property(e => e.MppMileDay7).HasColumnName("mpp_mile_day7");
            entity.Property(e => e.MppMilestonext).HasColumnName("mpp_milestonext");
            entity.Property(e => e.MppMisc1)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("mpp_misc1");
            entity.Property(e => e.MppMisc2)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("mpp_misc2");
            entity.Property(e => e.MppMisc3)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("mpp_misc3");
            entity.Property(e => e.MppMisc4)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("mpp_misc4");
            entity.Property(e => e.MppMtTypeEmpty)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_mt_type_empty");
            entity.Property(e => e.MppMtTypeLoaded)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_mt_type_loaded");
            entity.Property(e => e.MppNbrdependents).HasColumnName("mpp_nbrdependents");
            entity.Property(e => e.MppNextCity).HasColumnName("mpp_next_city");
            entity.Property(e => e.MppNextCmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_next_cmp_id");
            entity.Property(e => e.MppNextCmpOthertype1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_next_cmp_othertype1");
            entity.Property(e => e.MppNextEvent)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_next_event");
            entity.Property(e => e.MppNextLegnumber).HasColumnName("mpp_next_legnumber");
            entity.Property(e => e.MppNextRegion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_next_region1");
            entity.Property(e => e.MppNextRegion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_next_region2");
            entity.Property(e => e.MppNextRegion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_next_region3");
            entity.Property(e => e.MppNextRegion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_next_region4");
            entity.Property(e => e.MppNextState)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_next_state");
            entity.Property(e => e.MppNextStoparrival)
                .HasColumnType("datetime")
                .HasColumnName("mpp_next_stoparrival");
            entity.Property(e => e.MppNextStopnumber).HasColumnName("mpp_next_stopnumber");
            entity.Property(e => e.MppNote)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("mpp_note");
            entity.Property(e => e.MppNoteUpdatedate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_note_updatedate");
            entity.Property(e => e.MppOtherid)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("mpp_otherid");
            entity.Property(e => e.MppOverrideDefaultOt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_override_default_ot");
            entity.Property(e => e.MppPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mpp_password");
            entity.Property(e => e.MppPayto)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("mpp_payto");
            entity.Property(e => e.MppPerdiemEffDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_perdiem_eff_date");
            entity.Property(e => e.MppPerdiemFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_perdiem_flag");
            entity.Property(e => e.MppPeriodguarenteedhours)
                .HasColumnType("money")
                .HasColumnName("mpp_periodguarenteedhours");
            entity.Property(e => e.MppPlnCity)
                .HasDefaultValue(0)
                .HasColumnName("mpp_pln_city");
            entity.Property(e => e.MppPlnCmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("mpp_pln_cmp_id");
            entity.Property(e => e.MppPlnDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_pln_date");
            entity.Property(e => e.MppPlnLgh)
                .HasDefaultValue(0)
                .HasColumnName("mpp_pln_lgh");
            entity.Property(e => e.MppPreassignAckRequired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_preassign_ack_required");
            entity.Property(e => e.MppPriorCity).HasColumnName("mpp_prior_city");
            entity.Property(e => e.MppPriorCmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_prior_cmp_id");
            entity.Property(e => e.MppPriorCmpOthertype1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_prior_cmp_othertype1");
            entity.Property(e => e.MppPriorEvent)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_prior_event");
            entity.Property(e => e.MppPriorRegion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_prior_region1");
            entity.Property(e => e.MppPriorRegion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_prior_region2");
            entity.Property(e => e.MppPriorRegion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_prior_region3");
            entity.Property(e => e.MppPriorRegion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_prior_region4");
            entity.Property(e => e.MppPriorState)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_prior_state");
            entity.Property(e => e.MppProximitycardid)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("mpp_proximitycardid");
            entity.Property(e => e.MppPtaDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_pta_date");
            entity.Property(e => e.MppQualificationlist)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("mpp_qualificationlist");
            entity.Property(e => e.MppQuickentry)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength()
                .HasColumnName("mpp_quickentry");
            entity.Property(e => e.MppRevenuerate).HasColumnName("mpp_revenuerate");
            entity.Property(e => e.MppRtwDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_rtw_date");
            entity.Property(e => e.MppSenioritydate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_senioritydate");
            entity.Property(e => e.MppServicerule)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("8/70")
                .HasColumnName("mpp_servicerule");
            entity.Property(e => e.MppShiftEnd)
                .HasColumnType("datetime")
                .HasColumnName("mpp_shift_end");
            entity.Property(e => e.MppShiftStart)
                .HasColumnType("datetime")
                .HasColumnName("mpp_shift_start");
            entity.Property(e => e.MppShiftnumber)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_shiftnumber");
            entity.Property(e => e.MppSinglemilerate).HasColumnName("mpp_singlemilerate");
            entity.Property(e => e.MppSsn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mpp_ssn");
            entity.Property(e => e.MppState)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_state");
            entity.Property(e => e.MppStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("AVL")
                .HasColumnName("mpp_status");
            entity.Property(e => e.MppSubsistenceCmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_subsistence_cmp_id");
            entity.Property(e => e.MppSubsistenceEligible)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_subsistence_eligible");
            entity.Property(e => e.MppSubsistenceHomeCmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("mpp_subsistence_home_cmp_id");
            entity.Property(e => e.MppSubsistencePayRadius).HasColumnName("mpp_subsistence_pay_radius");
            entity.Property(e => e.MppSubsistenceUseAtHome)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_subsistence_use_at_home");
            entity.Property(e => e.MppTeamleader)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_teamleader");
            entity.Property(e => e.MppTeammilerate).HasColumnName("mpp_teammilerate");
            entity.Property(e => e.MppTerminal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_terminal");
            entity.Property(e => e.MppTerminationdt)
                .HasColumnType("datetime")
                .HasColumnName("mpp_terminationdt");
            entity.Property(e => e.MppTimeoffbetweenduty)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("mpp_timeoffbetweenduty");
            entity.Property(e => e.MppTractornumber)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("mpp_tractornumber");
            entity.Property(e => e.MppTrainAnvBonusAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_train_anv_bonus_amt");
            entity.Property(e => e.MppTrainAnvBonusEligDate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_train_anv_bonus_elig_date");
            entity.Property(e => e.MppTrainAnvBonusPd)
                .HasColumnType("datetime")
                .HasColumnName("mpp_train_anv_bonus_pd");
            entity.Property(e => e.MppTrainee)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_trainee");
            entity.Property(e => e.MppTrainer)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_trainer");
            entity.Property(e => e.MppTravelMinutes).HasColumnName("mpp_travel_minutes");
            entity.Property(e => e.MppTuitionAcctStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mpp_tuition_acct_status");
            entity.Property(e => e.MppTuitioncost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_tuitioncost");
            entity.Property(e => e.MppType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_type");
            entity.Property(e => e.MppType1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_type1");
            entity.Property(e => e.MppType2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_type2");
            entity.Property(e => e.MppType3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_type3");
            entity.Property(e => e.MppType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("mpp_type4");
            entity.Property(e => e.MppUpdatedby)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_sname())")
                .HasColumnName("mpp_updatedby");
            entity.Property(e => e.MppUpdateon)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("mpp_updateon");
            entity.Property(e => e.MppUpdtContDedNbr).HasColumnName("mpp_updt_cont_ded_nbr");
            entity.Property(e => e.MppUpdtContRemainBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_updt_cont_remain_balance");
            entity.Property(e => e.MppUpdtForgiveCrdNbr).HasColumnName("mpp_updt_forgive_crd_nbr");
            entity.Property(e => e.MppUpdtForgiveRemainBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mpp_updt_forgive_remain_balance");
            entity.Property(e => e.MppUsecashcard)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength()
                .HasColumnName("mpp_usecashcard");
            entity.Property(e => e.MppVoicemailbox)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mpp_voicemailbox");
            entity.Property(e => e.MppWantHome)
                .HasColumnType("datetime")
                .HasColumnName("mpp_want_home");
            entity.Property(e => e.MppWeeklyhrsest).HasColumnName("mpp_weeklyhrsest");
            entity.Property(e => e.MppYearsofsafedrive).HasColumnName("mpp_yearsofsafedrive");
            entity.Property(e => e.MppYsdasofdate)
                .HasColumnType("datetime")
                .HasColumnName("mpp_ysdasofdate");
            entity.Property(e => e.MppZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mpp_zip");
            entity.Property(e => e.OriginDestinationOption)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.RowsecRsrvId).HasColumnName("rowsec_rsrv_id");
            entity.Property(e => e.SthId).HasColumnName("sth_id");
            entity.Property(e => e.SthStartdate)
                .HasColumnType("datetime")
                .HasColumnName("sth_startdate");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
        });
        modelBuilder.HasSequence<int>("TransferHeaderSEQ").HasMin(1L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
