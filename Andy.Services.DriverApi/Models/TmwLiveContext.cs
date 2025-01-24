using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Andy.Services.DriverApi.Models;

public partial class TmwLiveContext : DbContext
{
    public TmwLiveContext()
    {
    }

    public TmwLiveContext(DbContextOptions<TmwLiveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AndyCityDriversList> AndyCityDriversLists { get; set; }

    public virtual DbSet<Legheader> Legheaders { get; set; }

    public virtual DbSet<Manpowerprofile> Manpowerprofiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AT-TMW-SQL\\TMW;Initial Catalog=TMW_Live;user=ANDYDOTNET; password=The5Wire!Hasslid ;Trusted_Connection=False;TrustServerCertificate=True;Persist Security Info=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AndyCityDriversList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ANDY_CIT__3213E83F036AC756");

            entity.ToTable("ANDY_CITY_DRIVERS_LIST");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Enddate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("enddate");
            entity.Property(e => e.MppId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("mpp_id");
            entity.Property(e => e.Startdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("startdate");
        });

        modelBuilder.Entity<Legheader>(entity =>
        {
            entity.HasKey(e => e.LghNumber).HasName("pk_legheader_lgh_number");

            entity.ToTable("legheader", tb =>
                {
                    tb.HasTrigger("TMW_Auto_Load_Assign");
                    tb.HasTrigger("dt_legheader_consolidated");
                    tb.HasTrigger("it_legheader_consolidated");
                    tb.HasTrigger("iut_legheader_active");
                    tb.HasTrigger("ut_legheader_consolidated");
                });

            entity.HasIndex(e => new { e.LghTractor, e.LghStartdate, e.LghEnddate }, "TractorDates");

            entity.HasIndex(e => new { e.LghNumber, e.LghEtaalert1 }, "_dta_index_legheader_5_1221579390__K1_K297_104_184").HasFillFactor(90);

            entity.HasIndex(e => new { e.MovNumber, e.LghNumber }, "_dta_index_legheader_5_1221579390__K44_K1_238_239_285_286_287_288").HasFillFactor(90);

            entity.HasIndex(e => new { e.LghActive, e.LghClass1 }, "d_lgh_active_class1");

            entity.HasIndex(e => e.LghLaneid, "dk_legheader_lgh_laneid");

            entity.HasIndex(e => new { e.MaTransactionId, e.MaTourNumber }, "dk_legheader_ma_tran_tour");

            entity.HasIndex(e => e.OrdHdrnumber, "dk_legheader_ord_hdrnumber");

            entity.HasIndex(e => new { e.LghCarrier, e.LghEnddate }, "dk_lgh_carrier_enddate");

            entity.HasIndex(e => new { e.LghClass3, e.OrdHdrnumber }, "dk_lgh_class3");

            entity.HasIndex(e => e.LghDriver1, "dk_lgh_driver1");

            entity.HasIndex(e => e.LghEnddate, "dk_lgh_enddate");

            entity.HasIndex(e => new { e.LghEtaalert1, e.LghActive }, "dk_lgh_etaalert1").IsDescending(true, false);

            entity.HasIndex(e => new { e.LghOutstatus, e.LghActive, e.LghInstatus, e.LghTractor, e.LghNumber }, "dk_lgh_outstat_active_instat_tractor_lghnum");

            entity.HasIndex(e => e.LghPlandate, "dk_lgh_plandate");

            entity.HasIndex(e => e.ShiftSsId, "dk_shift_ss_id");

            entity.HasIndex(e => new { e.LghTractor, e.LghOutstatus, e.LghInstatus }, "dk_tractor");

            entity.HasIndex(e => new { e.LghTractor, e.LghActive }, "dk_tractor_active");

            entity.HasIndex(e => new { e.LghDriver2, e.LghStartdate }, "idx_leg_lghdriver2_lghstartdate").HasFillFactor(90);

            entity.HasIndex(e => new { e.LghStartdate, e.LghEnddate }, "idx_leg_lghstartdate_lghenddate").HasFillFactor(90);

            entity.HasIndex(e => e.Timestamp, "idx_legheader_timestamp").HasFillFactor(90);

            entity.HasIndex(e => new { e.LghBookedRevtype1, e.LghCarrier }, "ix_lgh_booked_revtype").HasFillFactor(90);

            entity.HasIndex(e => e.LghRefnum, "ix_lgh_refnum");

            entity.HasIndex(e => new { e.LghDriver1, e.LghOutstatus, e.LghStartdate }, "ix_lh_dr1_outst_stdt").IsDescending(false, false, true);

            entity.HasIndex(e => new { e.LghDriver2, e.LghOutstatus, e.LghStartdate }, "ix_lh_dr2_outst_stdt").IsDescending(false, false, true);

            entity.HasIndex(e => new { e.LghPrimaryTrailer, e.LghOutstatus, e.LghStartdate }, "ix_lh_prtrl_outst").HasFillFactor(90);

            entity.HasIndex(e => new { e.LghStartdate, e.LghOutstatus }, "ix_lh_stdt_outstat").HasFillFactor(90);

            entity.HasIndex(e => e.LghTourNumber, "lgh_tour_index");

            entity.HasIndex(e => new { e.LghReftype, e.LghRefnum }, "sk_legheader_lgh_refnum");

            entity.HasIndex(e => new { e.LghUpdatedon, e.LghNumber }, "uk_lgh_updatedon_lgh_number").IsUnique();

            entity.HasIndex(e => new { e.MovNumber, e.LghStartcity, e.LghEndcity, e.LghBookedRevtype1 }, "uk_mov").HasFillFactor(90);

            entity.HasIndex(e => new { e.LghOutstatus, e.LghNumber }, "uk_status").IsUnique();

            entity.Property(e => e.LghNumber)
                .ValueGeneratedNever()
                .HasColumnName("lgh_number");
            entity.Property(e => e.CanCapExpires)
                .HasColumnType("datetime")
                .HasColumnName("can_cap_expires");
            entity.Property(e => e.CanLdExpires)
                .HasColumnType("datetime")
                .HasColumnName("can_ld_expires");
            entity.Property(e => e.CmdCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("cmd_code");
            entity.Property(e => e.CmpIdEnd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cmp_id_end");
            entity.Property(e => e.CmpIdRend)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cmp_id_rend");
            entity.Property(e => e.CmpIdRstart)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cmp_id_rstart");
            entity.Property(e => e.CmpIdStart)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cmp_id_start");
            entity.Property(e => e.DrvplanNumber).HasColumnName("drvplan_number");
            entity.Property(e => e.FgtDescription)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("fgt_description");
            entity.Property(e => e.FgtNumber).HasColumnName("fgt_number");
            entity.Property(e => e.Lgh204Tradingpartner)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("lgh_204_tradingpartner");
            entity.Property(e => e.Lgh204date)
                .HasColumnType("datetime")
                .HasColumnName("lgh_204date");
            entity.Property(e => e.Lgh204status)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_204status");
            entity.Property(e => e.Lgh204validate).HasColumnName("lgh_204validate");
            entity.Property(e => e.LghAccFsc)
                .HasColumnType("money")
                .HasColumnName("lgh_acc_fsc");
            entity.Property(e => e.LghAccSo1)
                .HasColumnType("money")
                .HasColumnName("lgh_acc_so1");
            entity.Property(e => e.LghAccSo2)
                .HasColumnType("money")
                .HasColumnName("lgh_acc_so2");
            entity.Property(e => e.LghAccSo3)
                .HasColumnType("money")
                .HasColumnName("lgh_acc_so3");
            entity.Property(e => e.LghAccSo4)
                .HasColumnType("money")
                .HasColumnName("lgh_acc_so4");
            entity.Property(e => e.LghAccSo5)
                .HasColumnType("money")
                .HasColumnName("lgh_acc_so5");
            entity.Property(e => e.LghAccSo6)
                .HasColumnType("money")
                .HasColumnName("lgh_acc_so6");
            entity.Property(e => e.LghAceStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_ace_status");
            entity.Property(e => e.LghActWeight).HasColumnName("lgh_act_weight");
            entity.Property(e => e.LghActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_active");
            entity.Property(e => e.LghActtransfer)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("lgh_acttransfer");
            entity.Property(e => e.LghActtransferdate)
                .HasDefaultValue(new DateTime(2049, 12, 31, 23, 59, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("lgh_acttransferdate");
            entity.Property(e => e.LghActualmiles)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("lgh_actualmiles");
            entity.Property(e => e.LghAllocRevenue)
                .HasColumnType("money")
                .HasColumnName("lgh_alloc_revenue");
            entity.Property(e => e.LghAllocfactor).HasColumnName("lgh_allocfactor");
            entity.Property(e => e.LghAssetLock)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_asset_lock");
            entity.Property(e => e.LghAssetLockDtm)
                .HasColumnType("datetime")
                .HasColumnName("lgh_asset_lock_dtm");
            entity.Property(e => e.LghAssetLockUser)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lgh_asset_lock_user");
            entity.Property(e => e.LghAutoloadmaxgvw).HasColumnName("lgh_autoloadmaxgvw");
            entity.Property(e => e.LghAvgRate)
                .HasColumnType("money")
                .HasColumnName("lgh_avg_rate");
            entity.Property(e => e.LghBookedRevtype1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("lgh_booked_revtype1");
            entity.Property(e => e.LghCarAccessorialCodes)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("lgh_car_accessorial_codes");
            entity.Property(e => e.LghCarAccessorialRates)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("lgh_car_accessorial_rates");
            entity.Property(e => e.LghCarAccessorials)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("lgh_car_accessorials");
            entity.Property(e => e.LghCarCharge)
                .HasColumnType("money")
                .HasColumnName("lgh_car_charge");
            entity.Property(e => e.LghCarRate)
                .HasColumnType("money")
                .HasColumnName("lgh_car_rate");
            entity.Property(e => e.LghCarTotalcharge)
                .HasColumnType("money")
                .HasColumnName("lgh_car_totalcharge");
            entity.Property(e => e.LghCarrier)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_carrier");
            entity.Property(e => e.LghChassis)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_chassis");
            entity.Property(e => e.LghChassis2)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_chassis2");
            entity.Property(e => e.LghClass1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_class1");
            entity.Property(e => e.LghClass2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_class2");
            entity.Property(e => e.LghClass3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_class3");
            entity.Property(e => e.LghClass4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_class4");
            entity.Property(e => e.LghComment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lgh_comment");
            entity.Property(e => e.LghCost).HasColumnName("lgh_cost");
            entity.Property(e => e.LghCreateapp)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("lgh_createapp");
            entity.Property(e => e.LghCreatedby)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("lgh_createdby");
            entity.Property(e => e.LghCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("lgh_createdon");
            entity.Property(e => e.LghDestzip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lgh_destzip");
            entity.Property(e => e.LghDetstatus).HasColumnName("lgh_detstatus");
            entity.Property(e => e.LghDirectRouteStatus1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_direct_route_status1");
            entity.Property(e => e.LghDispatchdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_dispatchdate");
            entity.Property(e => e.LghDolly)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_dolly");
            entity.Property(e => e.LghDolly2)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_dolly2");
            entity.Property(e => e.LghDriver1)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_driver1");
            entity.Property(e => e.LghDriver2)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_driver2");
            entity.Property(e => e.LghDrvtripnumber).HasColumnName("lgh_drvtripnumber");
            entity.Property(e => e.LghDspDate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_dsp_date");
            entity.Property(e => e.LghEdiCounter)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lgh_edi_counter");
            entity.Property(e => e.LghEndcity).HasColumnName("lgh_endcity");
            entity.Property(e => e.LghEndctyNmstct)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lgh_endcty_nmstct");
            entity.Property(e => e.LghEnddate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_enddate");
            entity.Property(e => e.LghEnddateArrival)
                .HasColumnType("datetime")
                .HasColumnName("lgh_enddate_arrival");
            entity.Property(e => e.LghEndlat).HasColumnName("lgh_endlat");
            entity.Property(e => e.LghEndlong).HasColumnName("lgh_endlong");
            entity.Property(e => e.LghEndregion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_endregion1");
            entity.Property(e => e.LghEndregion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_endregion2");
            entity.Property(e => e.LghEndregion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_endregion3");
            entity.Property(e => e.LghEndregion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_endregion4");
            entity.Property(e => e.LghEndstate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_endstate");
            entity.Property(e => e.LghEstWeight).HasColumnName("lgh_est_weight");
            entity.Property(e => e.LghEtaCmpList)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("lgh_eta_cmp_list");
            entity.Property(e => e.LghEtaEstEnddate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_eta_est_enddate");
            entity.Property(e => e.LghEtaEstStartdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_eta_est_startdate");
            entity.Property(e => e.LghEtaNextDrop)
                .HasColumnType("datetime")
                .HasColumnName("lgh_eta_next_drop");
            entity.Property(e => e.LghEtaNextPickup)
                .HasColumnType("datetime")
                .HasColumnName("lgh_eta_next_pickup");
            entity.Property(e => e.LghEtaalert1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_etaalert1");
            entity.Property(e => e.LghEtacalcdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_etacalcdate");
            entity.Property(e => e.LghEtacomment)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("lgh_etacomment");
            entity.Property(e => e.LghEtamilestofinal).HasColumnName("lgh_etamilestofinal");
            entity.Property(e => e.LghEtamins1).HasColumnName("lgh_etamins1");
            entity.Property(e => e.LghEtamintofinal).HasColumnName("lgh_etamintofinal");
            entity.Property(e => e.LghExternalratingMiles).HasColumnName("lgh_externalrating_miles");
            entity.Property(e => e.LghExtrainfo1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lgh_extrainfo1");
            entity.Property(e => e.LghExtrainfo2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lgh_extrainfo2");
            entity.Property(e => e.LghExtrainfo3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lgh_extrainfo3");
            entity.Property(e => e.LghFaxemailCreated)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_faxemail_created");
            entity.Property(e => e.LghFeetavailable).HasColumnName("lgh_feetavailable");
            entity.Property(e => e.LghFirstlegnumber).HasColumnName("lgh_firstlegnumber");
            entity.Property(e => e.LghFuelburned)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("lgh_fuelburned");
            entity.Property(e => e.LghFueltaxstatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_fueltaxstatus");
            entity.Property(e => e.LghFueltaxstatusdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_fueltaxstatusdate");
            entity.Property(e => e.LghGeoDate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_geo_date");
            entity.Property(e => e.LghHzdCmdClass)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_hzd_cmd_class");
            entity.Property(e => e.LghInstatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_instatus");
            entity.Property(e => e.LghLaneid).HasColumnName("lgh_laneid");
            entity.Property(e => e.LghLastlegnumber).HasColumnName("lgh_lastlegnumber");
            entity.Property(e => e.LghLdUnldTime).HasColumnName("lgh_ld_unld_time");
            entity.Property(e => e.LghLinehaul).HasColumnName("lgh_linehaul");
            entity.Property(e => e.LghLoadOrigin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lgh_load_origin");
            entity.Property(e => e.LghLoadTime).HasColumnName("lgh_load_time");
            entity.Property(e => e.LghManuallysettypeclass).HasColumnName("lgh_manuallysettypeclass");
            entity.Property(e => e.LghMaxWeightExceeded)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_max_weight_exceeded");
            entity.Property(e => e.LghMileOverageMessage)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("lgh_mile_overage_message");
            entity.Property(e => e.LghMiles).HasColumnName("lgh_miles");
            entity.Property(e => e.LghMilespractical).HasColumnName("lgh_milespractical");
            entity.Property(e => e.LghMilesshortest).HasColumnName("lgh_milesshortest");
            entity.Property(e => e.LghMppTypeEditdatetime)
                .HasColumnType("datetime")
                .HasColumnName("lgh_mpp_type_editdatetime");
            entity.Property(e => e.LghMtmiles).HasColumnName("lgh_mtmiles");
            entity.Property(e => e.LghNexttrailer1)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_nexttrailer1");
            entity.Property(e => e.LghNexttrailer2)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_nexttrailer2");
            entity.Property(e => e.LghNoautosplit).HasColumnName("lgh_noautosplit");
            entity.Property(e => e.LghNoautotransfer).HasColumnName("lgh_noautotransfer");
            entity.Property(e => e.LghOdometerend).HasColumnName("lgh_odometerend");
            entity.Property(e => e.LghOdometerstart).HasColumnName("lgh_odometerstart");
            entity.Property(e => e.LghOpCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_op_code");
            entity.Property(e => e.LghOptimizationdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_optimizationdate");
            entity.Property(e => e.LghOptimizedrouteid).HasColumnName("lgh_optimizedrouteid");
            entity.Property(e => e.LghOptimizestatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_optimizestatus");
            entity.Property(e => e.LghOrdCharge).HasColumnName("lgh_ord_charge");
            entity.Property(e => e.LghOrderSource)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_order_source");
            entity.Property(e => e.LghOriginzip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lgh_originzip");
            entity.Property(e => e.LghOtherStatus1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_other_status1");
            entity.Property(e => e.LghOtherStatus2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_other_status2");
            entity.Property(e => e.LghOutofrouteRouting)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_outofroute_routing");
            entity.Property(e => e.LghOutstatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_outstatus");
            entity.Property(e => e.LghPayTermCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_payTermCode");
            entity.Property(e => e.LghPermitStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_permit_status");
            entity.Property(e => e.LghPermitby)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("lgh_permitby");
            entity.Property(e => e.LghPermitdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_permitdate");
            entity.Property(e => e.LghPermitnumbers)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lgh_permitnumbers");
            entity.Property(e => e.LghPlandate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_plandate");
            entity.Property(e => e.LghPlannedhours)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("lgh_plannedhours");
            entity.Property(e => e.LghPrevSegStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_prev_seg_status");
            entity.Property(e => e.LghPrevSegStatusLastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("lgh_prev_seg_status_last_updated");
            entity.Property(e => e.LghPrimaryPup)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_primary_pup");
            entity.Property(e => e.LghPrimaryTrailer)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_primary_trailer");
            entity.Property(e => e.LghPriority)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_priority");
            entity.Property(e => e.LghPrjdate1)
                .HasColumnType("datetime")
                .HasColumnName("lgh_prjdate1");
            entity.Property(e => e.LghProdHr).HasColumnName("lgh_prod_hr");
            entity.Property(e => e.LghProtectedRate)
                .HasColumnType("money")
                .HasColumnName("lgh_protected_rate");
            entity.Property(e => e.LghRaildispatchstatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_raildispatchstatus");
            entity.Property(e => e.LghRailscheduleId).HasColumnName("lgh_railschedule_id");
            entity.Property(e => e.LghRailtemplatedetailId).HasColumnName("lgh_railtemplatedetail_id");
            entity.Property(e => e.LghRateDt)
                .HasColumnType("datetime")
                .HasColumnName("lgh_rate_dt");
            entity.Property(e => e.LghRateError)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lgh_rate_error");
            entity.Property(e => e.LghRateErrorDesc)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("lgh_rate_error_desc");
            entity.Property(e => e.LghRatemode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_ratemode");
            entity.Property(e => e.LghRecommendedCarId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_recommended_car_id");
            entity.Property(e => e.LghRefnum)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lgh_refnum");
            entity.Property(e => e.LghReftype)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_reftype");
            entity.Property(e => e.LghRendcity).HasColumnName("lgh_rendcity");
            entity.Property(e => e.LghRendctyNmstct)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lgh_rendcty_nmstct");
            entity.Property(e => e.LghRenddate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_renddate");
            entity.Property(e => e.LghRendlat).HasColumnName("lgh_rendlat");
            entity.Property(e => e.LghRendlong).HasColumnName("lgh_rendlong");
            entity.Property(e => e.LghRendregion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rendregion1");
            entity.Property(e => e.LghRendregion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rendregion2");
            entity.Property(e => e.LghRendregion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rendregion3");
            entity.Property(e => e.LghRendregion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rendregion4");
            entity.Property(e => e.LghRendstate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rendstate");
            entity.Property(e => e.LghRevenue).HasColumnName("lgh_revenue");
            entity.Property(e => e.LghRoute)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lgh_route");
            entity.Property(e => e.LghRstartcity).HasColumnName("lgh_rstartcity");
            entity.Property(e => e.LghRstartctyNmstct)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lgh_rstartcty_nmstct");
            entity.Property(e => e.LghRstartdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_rstartdate");
            entity.Property(e => e.LghRstartlat).HasColumnName("lgh_rstartlat");
            entity.Property(e => e.LghRstartlong).HasColumnName("lgh_rstartlong");
            entity.Property(e => e.LghRstartregion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rstartregion1");
            entity.Property(e => e.LghRstartregion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rstartregion2");
            entity.Property(e => e.LghRstartregion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rstartregion3");
            entity.Property(e => e.LghRstartregion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rstartregion4");
            entity.Property(e => e.LghRstartstate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_rstartstate");
            entity.Property(e => e.LghRtdId).HasColumnName("lgh_rtd_id");
            entity.Property(e => e.LghSchdtearliest)
                .HasColumnType("datetime")
                .HasColumnName("lgh_schdtearliest");
            entity.Property(e => e.LghSchdtlatest)
                .HasColumnType("datetime")
                .HasColumnName("lgh_schdtlatest");
            entity.Property(e => e.LghServicedays).HasColumnName("lgh_servicedays");
            entity.Property(e => e.LghServicelevel)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_servicelevel");
            entity.Property(e => e.LghShiftdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_shiftdate");
            entity.Property(e => e.LghShiftnumber)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_shiftnumber");
            entity.Property(e => e.LghShipStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_ship_status");
            entity.Property(e => e.LghSplitFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_split_flag");
            entity.Property(e => e.LghSpotRate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lgh_spot_rate");
            entity.Property(e => e.LghSpotRateUpdatedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lgh_spot_rate_updatedby");
            entity.Property(e => e.LghSpotRateUpdateddt)
                .HasColumnType("datetime")
                .HasColumnName("lgh_spot_rate_updateddt");
            entity.Property(e => e.LghStartcity).HasColumnName("lgh_startcity");
            entity.Property(e => e.LghStartctyNmstct)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lgh_startcty_nmstct");
            entity.Property(e => e.LghStartdate)
                .HasColumnType("datetime")
                .HasColumnName("lgh_startdate");
            entity.Property(e => e.LghStartlat).HasColumnName("lgh_startlat");
            entity.Property(e => e.LghStartlong).HasColumnName("lgh_startlong");
            entity.Property(e => e.LghStartregion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_startregion1");
            entity.Property(e => e.LghStartregion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_startregion2");
            entity.Property(e => e.LghStartregion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_startregion3");
            entity.Property(e => e.LghStartregion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_startregion4");
            entity.Property(e => e.LghStartstate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_startstate");
            entity.Property(e => e.LghTmStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("NOSENT")
                .HasColumnName("lgh_tm_status");
            entity.Property(e => e.LghTmstatusstopnumber).HasColumnName("lgh_tmstatusstopnumber");
            entity.Property(e => e.LghTotHr).HasColumnName("lgh_tot_hr");
            entity.Property(e => e.LghTotWeight).HasColumnName("lgh_tot_weight");
            entity.Property(e => e.LghTotalMovBillMiles).HasColumnName("lgh_total_mov_bill_miles");
            entity.Property(e => e.LghTotalMovMiles).HasColumnName("lgh_total_mov_miles");
            entity.Property(e => e.LghTourNumber).HasColumnName("lgh_tour_number");
            entity.Property(e => e.LghTractor)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_tractor");
            entity.Property(e => e.LghTrailer3)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_trailer3");
            entity.Property(e => e.LghTrailer4)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("lgh_trailer4");
            entity.Property(e => e.LghTrcComment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lgh_trc_comment");
            entity.Property(e => e.LghTriphours)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("lgh_triphours");
            entity.Property(e => e.LghTriphours2)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("lgh_triphours2");
            entity.Property(e => e.LghType1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("lgh_type1");
            entity.Property(e => e.LghType2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("lgh_type2");
            entity.Property(e => e.LghType3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_type3");
            entity.Property(e => e.LghType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_type4");
            entity.Property(e => e.LghType5)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("lgh_type5");
            entity.Property(e => e.LghUpdateapp)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("lgh_updateapp");
            entity.Property(e => e.LghUpdatedby)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("lgh_updatedby");
            entity.Property(e => e.LghUpdatedon)
                .HasColumnType("datetime")
                .HasColumnName("lgh_updatedon");
            entity.Property(e => e.LghWashplan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lgh_washplan");
            entity.Property(e => e.MaMppId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ma_mpp_id");
            entity.Property(e => e.MaTourNumber).HasColumnName("ma_tour_number");
            entity.Property(e => e.MaTourSequence).HasColumnName("ma_tour_sequence");
            entity.Property(e => e.MaTransactionId).HasColumnName("ma_transaction_id");
            entity.Property(e => e.MaTrcNumber)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ma_trc_number");
            entity.Property(e => e.MfhNumber).HasColumnName("mfh_number");
            entity.Property(e => e.MovNumber).HasColumnName("mov_number");
            entity.Property(e => e.Mpp2Type1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp2_type1");
            entity.Property(e => e.Mpp2Type2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp2_type2");
            entity.Property(e => e.Mpp2Type3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp2_type3");
            entity.Property(e => e.Mpp2Type4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp2_type4");
            entity.Property(e => e.MppCompany)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_company");
            entity.Property(e => e.MppDivision)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_division");
            entity.Property(e => e.MppDomicile)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_domicile");
            entity.Property(e => e.MppFleet)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_fleet");
            entity.Property(e => e.MppTeamleader)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_teamleader");
            entity.Property(e => e.MppTerminal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_terminal");
            entity.Property(e => e.MppType1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_type1");
            entity.Property(e => e.MppType2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_type2");
            entity.Property(e => e.MppType3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_type3");
            entity.Property(e => e.MppType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mpp_type4");
            entity.Property(e => e.OrdBillto)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_billto");
            entity.Property(e => e.OrdHdrnumber).HasColumnName("ord_hdrnumber");
            entity.Property(e => e.RailServiceLevel)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ShiftSsId).HasColumnName("shift_ss_id");
            entity.Property(e => e.StpNumberEnd).HasColumnName("stp_number_end");
            entity.Property(e => e.StpNumberRend).HasColumnName("stp_number_rend");
            entity.Property(e => e.StpNumberRstart).HasColumnName("stp_number_rstart");
            entity.Property(e => e.StpNumberStart).HasColumnName("stp_number_start");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.TrcCompany)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_company");
            entity.Property(e => e.TrcDivision)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_division");
            entity.Property(e => e.TrcFleet)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_fleet");
            entity.Property(e => e.TrcTeamleader)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_teamleader");
            entity.Property(e => e.TrcTerminal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_terminal");
            entity.Property(e => e.TrcType1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_type1");
            entity.Property(e => e.TrcType2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_type2");
            entity.Property(e => e.TrcType3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_type3");
            entity.Property(e => e.TrcType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trc_type4");
            entity.Property(e => e.TrlCompany)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_company");
            entity.Property(e => e.TrlDivision)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_division");
            entity.Property(e => e.TrlFleet)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_fleet");
            entity.Property(e => e.TrlTerminal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_terminal");
            entity.Property(e => e.TrlType1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_type1");
            entity.Property(e => e.TrlType2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_type2");
            entity.Property(e => e.TrlType3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_type3");
            entity.Property(e => e.TrlType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_type4");
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
