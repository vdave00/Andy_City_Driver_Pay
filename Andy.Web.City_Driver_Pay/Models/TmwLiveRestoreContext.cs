using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Andy.Web.City_Driver_Pay.Models;

public partial class TmwLiveRestoreContext : DbContext
{
    public TmwLiveRestoreContext()
    {
    }

    public TmwLiveRestoreContext(DbContextOptions<TmwLiveRestoreContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Legheader> Legheaders { get; set; }

    public virtual DbSet<Orderheader> Orderheaders { get; set; }

    public virtual DbSet<Paydetail> Paydetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AT-TMW-SQL\\TMW;Initial Catalog=TMW_Live_RESTORE;user=AndyWebDevOne; password=The5Wire!Hasslid ;Trusted_Connection=False;TrustServerCertificate=True;Persist Security Info=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Orderheader>(entity =>
        {
            entity.HasKey(e => e.OrdHdrnumber).HasName("pk_ordhdrnum");

            entity.ToTable("orderheader", tb =>
                {
                    tb.HasTrigger("dx_ut_orderheader");
                    tb.HasTrigger("it_ord");
                    tb.HasTrigger("it_orderheader");
                    tb.HasTrigger("it_ordersave");
                    tb.HasTrigger("orderheader_insert");
                    tb.HasTrigger("ut_ord");
                    tb.HasTrigger("ut_orderheader_QP");
                    tb.HasTrigger("ut_orderheader_fingerprinting");
                    tb.HasTrigger("ut_thirdpartystaging");
                });

            entity.HasIndex(e => e.OrdBookdate, "Andy_IX_OrderHeader_ord_bookdate").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdBookedRevtype1, e.OrdBillto, e.OrdStatus, e.OrdInvoicestatus }, "IDX_orderheader_billffg");

            entity.HasIndex(e => new { e.OrdBillto, e.OrdStatus }, "IX_ANDY_OH_BILLTO_STATUS").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdBillto, e.OrdStatus }, "IX_orderheader_ord_billto_ord_status_13AE5").HasFillFactor(90);

            entity.HasIndex(e => e.OrdInvoicestatus, "Inx_orheader_invoicstat").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdHdrnumber, e.OrdBillto, e.OrdStatus, e.OrdStartdate, e.OrdRevtype2, e.OrdCompletiondate }, "_dta_index_orderheader_5_882102183__K31_K17_K6_K18_K21_K19").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdHdrnumber, e.RowsecRsrvId, e.OrdTotalcharge, e.TrlType1, e.OrdBookedRevtype1, e.OrdBookedby, e.OrdBillto, e.OrdCompany, e.OrdRefnum, e.OrdStatus, e.OrdPriority, e.OrdShipper, e.OrdConsignee, e.OrdRemark }, "_dta_index_orderheader_5_882102183__K31_K277_K27_K63_K118_K5_K17_K1_K32_K6_K46_K35_K36_K34_2_26_28").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdHdrnumber, e.OrdTotalcharge }, "_dta_index_orderheader_5_882102183__K31_K27_26_28").HasFillFactor(90);

            entity.HasIndex(e => e.OrdBookdate, "_dta_index_orderheader_5_882102183__K4").HasFillFactor(90);

            entity.HasIndex(e => e.OrdDestcity, "dk_dcity");

            entity.HasIndex(e => new { e.MovNumber, e.OrdBillto }, "dk_mov_number").HasFillFactor(95);

            entity.HasIndex(e => e.OrdOrigincity, "dk_ocity");

            entity.HasIndex(e => e.OrdBillto, "dk_ord_billto");

            entity.HasIndex(e => new { e.OrdBookdate, e.OrdRevtype3, e.OrdBillto }, "dk_ord_bookdate_revtype3_billto");

            entity.HasIndex(e => e.OrdConsignee, "dk_ord_cns");

            entity.HasIndex(e => new { e.OrdOrderSource, e.OrdStatus }, "dk_ord_order_source");

            entity.HasIndex(e => new { e.OrdOrderSource, e.OrdStatus, e.OrdTotalmiles, e.OrdEdistate }, "dk_ord_order_source_status").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdOriginEarliestdate, e.OrdStatus, e.OrdBookedRevtype1, e.MovNumber, e.OrdOrigincity, e.OrdDestcity }, "dk_ord_orgerldt_stat_rev_mov_city");

            entity.HasIndex(e => new { e.OrdStatus, e.MovNumber, e.OrdOrigincity, e.OrdDestcity, e.OrdBookedRevtype1 }, "dk_ord_status_mov").HasFillFactor(90);

            entity.HasIndex(e => e.ExternalId, "dk_order_external_id");

            entity.HasIndex(e => e.OrdRoute, "dk_orderheader_ord_route").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdRevtype1, e.OrdInvoicestatus }, "dk_rev1_invstatus");

            entity.HasIndex(e => e.OrdShipper, "dk_shipper");

            entity.HasIndex(e => new { e.OrdStatus, e.OrdRailschedulecascadepending, e.OrdMastermatchpending }, "dx_matching").HasFillFactor(90);

            entity.HasIndex(e => e.Timestamp, "idx_orderheader_timestamp").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdStatus, e.OrdInvoicestatus }, "ix_odrhdr_status_invstat").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdCompletiondate, e.OrdStatus }, "ix_ord_completiondate_status");

            entity.HasIndex(e => e.OrdFromorder, "ix_ord_fromorder");

            entity.HasIndex(e => new { e.OrdStartdate, e.OrdStatus }, "ordhdr_ordstartdate");

            entity.HasIndex(e => e.OrdNumber, "pk_ord_number").IsUnique();

            entity.HasIndex(e => e.OrdCompany, "sk_ord_company");

            entity.HasIndex(e => new { e.OrdStatus, e.OrdCompletiondate }, "sk_ord_status").HasFillFactor(90);

            entity.HasIndex(e => new { e.OrdRefnum, e.OrdReftype, e.OrdHdrnumber }, "sk_orderheader_ord_refnum");

            entity.Property(e => e.OrdHdrnumber)
                .ValueGeneratedNever()
                .HasColumnName("ord_hdrnumber");
            entity.Property(e => e.ApptContact)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("appt_contact");
            entity.Property(e => e.ApptInit)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("appt_init");
            entity.Property(e => e.Billingcloseddate)
                .HasColumnType("datetime")
                .HasColumnName("billingcloseddate");
            entity.Property(e => e.CarKey).HasColumnName("car_key");
            entity.Property(e => e.ChtItemcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cht_itemcode");
            entity.Property(e => e.CmdCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("cmd_code");
            entity.Property(e => e.ExternalId).HasColumnName("external_id");
            entity.Property(e => e.ExternalType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("external_type");
            entity.Property(e => e.GstReq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GST_REQ");
            entity.Property(e => e.HstReq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("HST_REQ");
            entity.Property(e => e.IvaReq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IVA_REQ");
            entity.Property(e => e.LastUpdateby)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("last_updateby");
            entity.Property(e => e.LastUpdatedate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updatedate");
            entity.Property(e => e.MfhHdrnumber).HasColumnName("mfh_hdrnumber");
            entity.Property(e => e.MovNumber).HasColumnName("mov_number");
            entity.Property(e => e.OptTrcType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("opt_trc_type4");
            entity.Property(e => e.OptTrlType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("opt_trl_type4");
            entity.Property(e => e.OrdAccessorialChrg)
                .HasColumnType("money")
                .HasColumnName("ord_accessorial_chrg");
            entity.Property(e => e.OrdAccounttype)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_accounttype");
            entity.Property(e => e.OrdAllinclusivecharge)
                .HasColumnType("money")
                .HasColumnName("ord_allinclusivecharge");
            entity.Property(e => e.OrdAncNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ord_anc_number");
            entity.Property(e => e.OrdAppEqcodes)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("ord_app_eqcodes");
            entity.Property(e => e.OrdApproved)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_approved");
            entity.Property(e => e.OrdAvailabledate)
                .HasColumnType("datetime")
                .HasColumnName("ord_availabledate");
            entity.Property(e => e.OrdBarcode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_barcode");
            entity.Property(e => e.OrdBatchrateeligibility)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_batchrateeligibility");
            entity.Property(e => e.OrdBatchratestatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_batchratestatus");
            entity.Property(e => e.OrdBelongsTo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_BelongsTo");
            entity.Property(e => e.OrdBillingUsedate)
                .HasColumnType("datetime")
                .HasColumnName("ord_billing_usedate");
            entity.Property(e => e.OrdBillingUsedateSetting)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_billing_usedate_setting");
            entity.Property(e => e.OrdBillmiles)
                .HasColumnType("money")
                .HasColumnName("ord_billmiles");
            entity.Property(e => e.OrdBillto)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_billto");
            entity.Property(e => e.OrdBolPrinted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ord_bol_printed");
            entity.Property(e => e.OrdBookdate)
                .HasColumnType("datetime")
                .HasColumnName("ord_bookdate");
            entity.Property(e => e.OrdBookedRevtype1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("UNK")
                .HasColumnName("ord_booked_revtype1");
            entity.Property(e => e.OrdBookedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_bookedby");
            entity.Property(e => e.OrdBroker)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ord_broker");
            entity.Property(e => e.OrdBrokerPercent)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("ord_broker_percent");
            entity.Property(e => e.OrdCarrier)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_carrier");
            entity.Property(e => e.OrdCarrierchangecode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_carrierchangecode");
            entity.Property(e => e.OrdCbp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_cbp");
            entity.Property(e => e.OrdCharge)
                .HasColumnType("money")
                .HasColumnName("ord_charge");
            entity.Property(e => e.OrdChargeType).HasColumnName("ord_charge_type");
            entity.Property(e => e.OrdChargeTypeLh).HasColumnName("ord_charge_type_lh");
            entity.Property(e => e.OrdChassis)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ord_chassis");
            entity.Property(e => e.OrdChassis2)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ord_chassis2");
            entity.Property(e => e.OrdChecklisttype)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_checklisttype");
            entity.Property(e => e.OrdCmdvalue)
                .HasColumnType("money")
                .HasColumnName("ord_cmdvalue");
            entity.Property(e => e.OrdCodAmount)
                .HasColumnType("money")
                .HasColumnName("ord_cod_amount");
            entity.Property(e => e.OrdCommoditiesWeight).HasColumnName("ord_commodities_weight");
            entity.Property(e => e.OrdCompany)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_company");
            entity.Property(e => e.OrdCompleteStamp)
                .HasColumnType("datetime")
                .HasColumnName("ord_complete_stamp");
            entity.Property(e => e.OrdCompletiondate)
                .HasColumnType("datetime")
                .HasColumnName("ord_completiondate");
            entity.Property(e => e.OrdConsignee)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_consignee");
            entity.Property(e => e.OrdContact)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_contact");
            entity.Property(e => e.OrdCurrency)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_currency");
            entity.Property(e => e.OrdCurrencydate)
                .HasColumnType("datetime")
                .HasColumnName("ord_currencydate");
            entity.Property(e => e.OrdCustomdate)
                .HasColumnType("datetime")
                .HasColumnName("ord_customdate");
            entity.Property(e => e.OrdCustomer)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_customer");
            entity.Property(e => e.OrdCustomsDocument)
                .HasDefaultValue(0)
                .HasColumnName("ord_customs_document");
            entity.Property(e => e.OrdCyclicDspEnabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_cyclic_dsp_enabled");
            entity.Property(e => e.OrdDatepromised)
                .HasColumnType("datetime")
                .HasColumnName("ord_datepromised");
            entity.Property(e => e.OrdDatetaken)
                .HasColumnType("datetime")
                .HasColumnName("ord_datetaken");
            entity.Property(e => e.OrdDelRptSent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_DelRptSent");
            entity.Property(e => e.OrdDescription)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ord_description");
            entity.Property(e => e.OrdDestEarliestdate)
                .HasColumnType("datetime")
                .HasColumnName("ord_dest_earliestdate");
            entity.Property(e => e.OrdDestLatestdate)
                .HasColumnType("datetime")
                .HasColumnName("ord_dest_latestdate");
            entity.Property(e => e.OrdDestZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ord_dest_zip");
            entity.Property(e => e.OrdDestcity).HasColumnName("ord_destcity");
            entity.Property(e => e.OrdDestpoint)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_destpoint");
            entity.Property(e => e.OrdDestregion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_destregion1");
            entity.Property(e => e.OrdDestregion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_destregion2");
            entity.Property(e => e.OrdDestregion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_destregion3");
            entity.Property(e => e.OrdDestregion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_destregion4");
            entity.Property(e => e.OrdDeststate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_deststate");
            entity.Property(e => e.OrdDimfactor)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("ord_dimfactor");
            entity.Property(e => e.OrdDistributor)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_distributor");
            entity.Property(e => e.OrdDrAt)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_dr_at");
            entity.Property(e => e.OrdDriver1)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_driver1");
            entity.Property(e => e.OrdDriver2)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_driver2");
            entity.Property(e => e.OrdDrivetime).HasColumnName("ord_drivetime");
            entity.Property(e => e.OrdEdiaccepttext)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ord_ediaccepttext");
            entity.Property(e => e.OrdEdideclinereason)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_edideclinereason");
            entity.Property(e => e.OrdEdipurpose)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ord_edipurpose");
            entity.Property(e => e.OrdEdistate).HasColumnName("ord_edistate");
            entity.Property(e => e.OrdEdistatePrior).HasColumnName("ord_edistate_prior");
            entity.Property(e => e.OrdEditradingpartner)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ord_editradingpartner");
            entity.Property(e => e.OrdEdiuseraction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ord_ediuseraction");
            entity.Property(e => e.OrdEntryport)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("ord_entryport");
            entity.Property(e => e.OrdExitport)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("ord_exitport");
            entity.Property(e => e.OrdExtequipAutomatch)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_extequip_automatch");
            entity.Property(e => e.OrdExtrainfo1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo1");
            entity.Property(e => e.OrdExtrainfo10)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo10");
            entity.Property(e => e.OrdExtrainfo11)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo11");
            entity.Property(e => e.OrdExtrainfo12)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo12");
            entity.Property(e => e.OrdExtrainfo13)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo13");
            entity.Property(e => e.OrdExtrainfo14)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo14");
            entity.Property(e => e.OrdExtrainfo15)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo15");
            entity.Property(e => e.OrdExtrainfo2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo2");
            entity.Property(e => e.OrdExtrainfo3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo3");
            entity.Property(e => e.OrdExtrainfo4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo4");
            entity.Property(e => e.OrdExtrainfo5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo5");
            entity.Property(e => e.OrdExtrainfo6)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo6");
            entity.Property(e => e.OrdExtrainfo7)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo7");
            entity.Property(e => e.OrdExtrainfo8)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo8");
            entity.Property(e => e.OrdExtrainfo9)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_extrainfo9");
            entity.Property(e => e.OrdFromorder)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ord_fromorder");
            entity.Property(e => e.OrdFromschedule).HasColumnName("ord_fromschedule");
            entity.Property(e => e.OrdGrossweight).HasColumnName("ord_grossweight");
            entity.Property(e => e.OrdGvwAdjstdAmt)
                .HasColumnType("numeric(19, 4)")
                .HasColumnName("ord_gvw_adjstd_amt");
            entity.Property(e => e.OrdGvwAdjstdUnit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_gvw_adjstd_unit");
            entity.Property(e => e.OrdGvwAmt)
                .HasColumnType("numeric(19, 4)")
                .HasColumnName("ord_gvw_amt");
            entity.Property(e => e.OrdGvwUnit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_gvw_unit");
            entity.Property(e => e.OrdHeight)
                .HasColumnType("money")
                .HasColumnName("ord_height");
            entity.Property(e => e.OrdHeightunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_heightunit");
            entity.Property(e => e.OrdHideconsignaddr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_hideconsignaddr");
            entity.Property(e => e.OrdHideshipperaddr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_hideshipperaddr");
            entity.Property(e => e.OrdHitemp).HasColumnName("ord_hitemp");
            entity.Property(e => e.OrdImportexport)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_importexport");
            entity.Property(e => e.OrdIntermodal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_intermodal");
            entity.Property(e => e.OrdInvoiceEffectivedate)
                .HasColumnType("datetime")
                .HasColumnName("ord_invoice_effectivedate");
            entity.Property(e => e.OrdInvoicestatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_invoicestatus");
            entity.Property(e => e.OrdInvoicewhole)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_invoicewhole");
            entity.Property(e => e.OrdJobFreightbased).HasColumnName("ord_job_freightbased");
            entity.Property(e => e.OrdJobOrdered).HasColumnName("ord_job_ordered");
            entity.Property(e => e.OrdJobRemaining).HasColumnName("ord_job_remaining");
            entity.Property(e => e.OrdLastratedate)
                .HasColumnType("datetime")
                .HasColumnName("ord_lastratedate");
            entity.Property(e => e.OrdLength)
                .HasColumnType("money")
                .HasColumnName("ord_length");
            entity.Property(e => e.OrdLengthunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_lengthunit");
            entity.Property(e => e.OrdLoadtime).HasColumnName("ord_loadtime");
            entity.Property(e => e.OrdLowtemp).HasColumnName("ord_lowtemp");
            entity.Property(e => e.OrdManualcheckcallminutes).HasColumnName("ord_manualcheckcallminutes");
            entity.Property(e => e.OrdManualeventcallminutes).HasColumnName("ord_manualeventcallminutes");
            entity.Property(e => e.OrdMastermatchpending)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_mastermatchpending");
            entity.Property(e => e.OrdMaxtemp).HasColumnName("ord_maxtemp");
            entity.Property(e => e.OrdMileageAdjPct)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("ord_mileage_adj_pct");
            entity.Property(e => e.OrdMileagetable)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ord_mileagetable");
            entity.Property(e => e.OrdMintemp).HasColumnName("ord_mintemp");
            entity.Property(e => e.OrdMiscdate1)
                .HasColumnType("datetime")
                .HasColumnName("ord_miscdate1");
            entity.Property(e => e.OrdMiscqty)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("ord_miscqty");
            entity.Property(e => e.OrdNoRecalcMiles)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_no_recalc_miles");
            entity.Property(e => e.OrdNoautosplit).HasColumnName("ord_noautosplit");
            entity.Property(e => e.OrdNoautotransfer).HasColumnName("ord_noautotransfer");
            entity.Property(e => e.OrdNomincharges)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_nomincharges");
            entity.Property(e => e.OrdNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_number");
            entity.Property(e => e.OrdOdmetermiles).HasColumnName("ord_odmetermiles");
            entity.Property(e => e.OrdOdmetermilesMtid).HasColumnName("ord_odmetermiles_mtid");
            entity.Property(e => e.OrdOdometerEnd).HasColumnName("ord_odometer_end");
            entity.Property(e => e.OrdOdometerStart).HasColumnName("ord_odometer_start");
            entity.Property(e => e.OrdOrderSource)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_order_source");
            entity.Property(e => e.OrdOriginEarliestdate)
                .HasColumnType("datetime")
                .HasColumnName("ord_origin_earliestdate");
            entity.Property(e => e.OrdOriginLatestdate)
                .HasColumnType("datetime")
                .HasColumnName("ord_origin_latestdate");
            entity.Property(e => e.OrdOriginZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ord_origin_zip");
            entity.Property(e => e.OrdOrigincity).HasColumnName("ord_origincity");
            entity.Property(e => e.OrdOriginpoint)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_originpoint");
            entity.Property(e => e.OrdOriginregion1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_originregion1");
            entity.Property(e => e.OrdOriginregion2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_originregion2");
            entity.Property(e => e.OrdOriginregion3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_originregion3");
            entity.Property(e => e.OrdOriginregion4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_originregion4");
            entity.Property(e => e.OrdOriginstate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_originstate");
            entity.Property(e => e.OrdOverCreditLimitApproved)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ord_over_credit_limit_approved");
            entity.Property(e => e.OrdOverCreditLimitApprovedBy)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("ord_over_credit_limit_approved_by");
            entity.Property(e => e.OrdOverrideStopType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_override_stop_type");
            entity.Property(e => e.OrdPalletCount).HasColumnName("ord_pallet_count");
            entity.Property(e => e.OrdPalletType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_pallet_type");
            entity.Property(e => e.OrdPaymiles)
                .HasColumnType("money")
                .HasColumnName("ord_paymiles");
            entity.Property(e => e.OrdPaystatusOverride)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_paystatus_override");
            entity.Property(e => e.OrdPendinglegstatusupdate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_pendinglegstatusupdate");
            entity.Property(e => e.OrdPin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ord_pin");
            entity.Property(e => e.OrdPreassignAckRequired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_preassign_ack_required");
            entity.Property(e => e.OrdPreventexternalupdate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_preventexternalupdate");
            entity.Property(e => e.OrdPriority)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_priority");
            entity.Property(e => e.OrdPuAt)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_pu_at");
            entity.Property(e => e.OrdPydStatus1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("NPD")
                .HasColumnName("ord_pyd_status_1");
            entity.Property(e => e.OrdPydStatus2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("NPD")
                .HasColumnName("ord_pyd_status_2");
            entity.Property(e => e.OrdQuantity).HasColumnName("ord_quantity");
            entity.Property(e => e.OrdQuantityType).HasColumnName("ord_quantity_type");
            entity.Property(e => e.OrdRaildest)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ord_raildest");
            entity.Property(e => e.OrdRailpoolid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_railpoolid");
            entity.Property(e => e.OrdRailrampdest)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_railrampdest");
            entity.Property(e => e.OrdRailramporig)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_railramporig");
            entity.Property(e => e.OrdRailschedulecascadepending)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_railschedulecascadepending");
            entity.Property(e => e.OrdRate)
                .HasColumnType("money")
                .HasColumnName("ord_rate");
            entity.Property(e => e.OrdRateMileagetable)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ord_rate_mileagetable");
            entity.Property(e => e.OrdRateType).HasColumnName("ord_rate_type");
            entity.Property(e => e.OrdRateby)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_rateby");
            entity.Property(e => e.OrdRatemode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_ratemode");
            entity.Property(e => e.OrdRateunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_rateunit");
            entity.Property(e => e.OrdRatingquantity).HasColumnName("ord_ratingquantity");
            entity.Property(e => e.OrdRatingunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_ratingunit");
            entity.Property(e => e.OrdRefnum)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ord_refnum");
            entity.Property(e => e.OrdReftype)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_reftype");
            entity.Property(e => e.OrdRemark)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("ord_remark");
            entity.Property(e => e.OrdRemark2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ord_remark2");
            entity.Property(e => e.OrdReservedNumber)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_reserved_number");
            entity.Property(e => e.OrdRevenuePay)
                .HasColumnType("money")
                .HasColumnName("ord_revenue_pay");
            entity.Property(e => e.OrdRevenuePayFix)
                .HasDefaultValue(0)
                .HasColumnName("ord_revenue_pay_fix");
            entity.Property(e => e.OrdReviewed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_reviewed");
            entity.Property(e => e.OrdReviewedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ord_reviewedby");
            entity.Property(e => e.OrdRevieweddate)
                .HasColumnType("datetime")
                .HasColumnName("ord_revieweddate");
            entity.Property(e => e.OrdReviewneeded)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_reviewneeded");
            entity.Property(e => e.OrdRevtype1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_revtype1");
            entity.Property(e => e.OrdRevtype2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_revtype2");
            entity.Property(e => e.OrdRevtype3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_revtype3");
            entity.Property(e => e.OrdRevtype4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_revtype4");
            entity.Property(e => e.OrdRoute)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ord_route");
            entity.Property(e => e.OrdRouteEffcDate)
                .HasColumnType("datetime")
                .HasColumnName("ord_route_effc_date");
            entity.Property(e => e.OrdRouteExpDate)
                .HasColumnType("datetime")
                .HasColumnName("ord_route_exp_date");
            entity.Property(e => e.OrdRoutename)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ord_routename");
            entity.Property(e => e.OrdSchedulebatch).HasColumnName("ord_schedulebatch");
            entity.Property(e => e.OrdServicedays).HasColumnName("ord_servicedays");
            entity.Property(e => e.OrdServicelevel)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_servicelevel");
            entity.Property(e => e.OrdShipper)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_shipper");
            entity.Property(e => e.OrdShortcomment)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_shortcomment");
            entity.Property(e => e.OrdShowasconsigneeDist).HasColumnName("ord_showasconsignee_dist");
            entity.Property(e => e.OrdShowcons)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_showcons");
            entity.Property(e => e.OrdShowshipper)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_showshipper");
            entity.Property(e => e.OrdStandardhours)
                .HasColumnType("money")
                .HasColumnName("ord_standardhours");
            entity.Property(e => e.OrdStartdate)
                .HasColumnType("datetime")
                .HasColumnName("ord_startdate");
            entity.Property(e => e.OrdStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_status");
            entity.Property(e => e.OrdStlquantity).HasColumnName("ord_stlquantity");
            entity.Property(e => e.OrdStlquantityType).HasColumnName("ord_stlquantity_type");
            entity.Property(e => e.OrdStlunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_stlunit");
            entity.Property(e => e.OrdStopcount).HasColumnName("ord_stopcount");
            entity.Property(e => e.OrdSubcompany)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_subcompany");
            entity.Property(e => e.OrdSubmode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_submode");
            entity.Property(e => e.OrdSupplier)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_supplier");
            entity.Property(e => e.OrdTareweight).HasColumnName("ord_tareweight");
            entity.Property(e => e.OrdTargetMargin)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("ord_target_margin");
            entity.Property(e => e.OrdTempunits)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_tempunits");
            entity.Property(e => e.OrdTerms)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_terms");
            entity.Property(e => e.OrdThirdpartySplit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_thirdparty_split");
            entity.Property(e => e.OrdThirdpartySplitPercent).HasColumnName("ord_thirdparty_split_percent");
            entity.Property(e => e.OrdThirdpartytype1)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_thirdpartytype1");
            entity.Property(e => e.OrdThirdpartytype2)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_thirdpartytype2");
            entity.Property(e => e.OrdThirdpartytype3)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_thirdpartytype3");
            entity.Property(e => e.OrdTimezone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ord_timezone");
            entity.Property(e => e.OrdTollCost)
                .HasColumnType("money")
                .HasColumnName("ord_toll_cost");
            entity.Property(e => e.OrdTollCostUpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ord_toll_cost_update_date");
            entity.Property(e => e.OrdTotalcharge).HasColumnName("ord_totalcharge");
            entity.Property(e => e.OrdTotalcountunits)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_totalcountunits");
            entity.Property(e => e.OrdTotalloadingmeters)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("ord_totalloadingmeters");
            entity.Property(e => e.OrdTotalloadingmetersunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_totalloadingmetersunit");
            entity.Property(e => e.OrdTotalmiles).HasColumnName("ord_totalmiles");
            entity.Property(e => e.OrdTotalpieces)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ord_totalpieces");
            entity.Property(e => e.OrdTotalvolume).HasColumnName("ord_totalvolume");
            entity.Property(e => e.OrdTotalvolumeunits)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_totalvolumeunits");
            entity.Property(e => e.OrdTotalweight).HasColumnName("ord_totalweight");
            entity.Property(e => e.OrdTotalweightunits)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_totalweightunits");
            entity.Property(e => e.OrdTractor)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ord_tractor");
            entity.Property(e => e.OrdTrailer)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ord_trailer");
            entity.Property(e => e.OrdTrailer2)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ord_trailer2");
            entity.Property(e => e.OrdTriprptLastRundate)
                .HasColumnType("datetime")
                .HasColumnName("ord_triprpt_last_rundate");
            entity.Property(e => e.OrdTrlConfiguration)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_TrlConfiguration");
            entity.Property(e => e.OrdTrlType2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_trl_type2");
            entity.Property(e => e.OrdTrlType3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_trl_type3");
            entity.Property(e => e.OrdTrlType4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_trl_type4");
            entity.Property(e => e.OrdTrlrentinv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_trlrentinv");
            entity.Property(e => e.OrdUnit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_unit");
            entity.Property(e => e.OrdUnloadtime).HasColumnName("ord_unloadtime");
            entity.Property(e => e.OrdUnlockKey).HasColumnName("Ord_UnlockKey");
            entity.Property(e => e.OrdUseShowasconsigneeDist)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ord_use_showasconsignee_dist");
            entity.Property(e => e.OrdWidth)
                .HasColumnType("money")
                .HasColumnName("ord_width");
            entity.Property(e => e.OrdWidthunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ord_widthunit");
            entity.Property(e => e.Payrollcloseddate)
                .HasColumnType("datetime")
                .HasColumnName("payrollcloseddate");
            entity.Property(e => e.QstReq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("QST_REQ");
            entity.Property(e => e.RecurringJobFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("recurring_job_flag");
            entity.Property(e => e.RefPickup)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ref_pickup");
            entity.Property(e => e.RefSid)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ref_sid");
            entity.Property(e => e.RowsecRsrvId).HasColumnName("rowsec_rsrv_id");
            entity.Property(e => e.SvManuExportFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("sv_manu_export_flag");
            entity.Property(e => e.TarNumber).HasColumnName("tar_number");
            entity.Property(e => e.TarTariffitem)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("tar_tariffitem");
            entity.Property(e => e.TarTarriffnumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("tar_tarriffnumber");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.TrlType1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("trl_type1");
        });

        modelBuilder.Entity<Paydetail>(entity =>
        {
            entity.HasKey(e => e.PydNumber).HasName("pk_pyd_number");

            entity.ToTable("paydetail", tb =>
                {
                    tb.HasTrigger("dt_paydetail_QP");
                    tb.HasTrigger("it_paydetail_QP");
                    tb.HasTrigger("itpaydetail");
                    tb.HasTrigger("iut_paydetail_andy");
                    tb.HasTrigger("ut_paydetail_QP");
                    tb.HasTrigger("utdtpaydetail");
                });

            entity.HasIndex(e => new { e.PydStatus, e.AsgnType, e.AsgnId, e.PyhNumber, e.PyhPayperiod }, "IDX_PYD_STATUS_ASSET_HEADER").HasFillFactor(90);

            entity.HasIndex(e => e.IvdNumber, "IDX_paydetail_ivd_number");

            entity.HasIndex(e => new { e.AsgnType, e.AsgnId, e.PyhPayperiod }, "ck_type_id");

            entity.HasIndex(e => e.AsgnNumber, "dk_asgnnum");

            entity.HasIndex(e => new { e.PytItemcode, e.PydWorkperiod }, "dk_itemcodeworkper");

            entity.HasIndex(e => new { e.LghNumber, e.PyhNumber, e.PydStatus }, "dk_lghnum").HasFillFactor(90);

            entity.HasIndex(e => e.OrdHdrnumber, "dk_ordhdrnumber");

            entity.HasIndex(e => e.PydIvhHdrnumber, "dk_pyd_ivh_hdrnumber");

            entity.HasIndex(e => e.PydStatus, "dk_pyd_status");

            entity.HasIndex(e => e.PydTransdate, "dk_pyd_transdate");

            entity.HasIndex(e => new { e.AsgnType, e.AsgnId, e.LghNumber }, "dk_pyd_type_id_lghnum");

            entity.HasIndex(e => e.MovNumber, "dx_mov_number");

            entity.HasIndex(e => e.PydAtdId, "idx_paydetail_pyd_atd_id").HasFillFactor(90);

            entity.HasIndex(e => e.PydSmwldId, "idx_paydetail_pyd_smwld_id").HasFillFactor(90);

            entity.HasIndex(e => e.PydUpdatedon, "idx_paydetail_pyd_updatedon").HasFillFactor(90);

            entity.HasIndex(e => e.DwTimestamp, "idx_paydetail_timestamp").HasFillFactor(90);

            entity.HasIndex(e => new { e.PyhPayperiod, e.PydStatus, e.PydPretax, e.PydMinus }, "ix_pd_payperiod_status_pretax_minus").HasFillFactor(95);

            entity.HasIndex(e => new { e.AsgnType, e.MovNumber, e.LghNumber, e.AsgnId, e.PydAmount }, "ix_pd_type_mov_lgh_id_amt").HasFillFactor(80);

            entity.HasIndex(e => new { e.AsgnId, e.AsgnType, e.PydNumber, e.PydStatus, e.PyhPayperiod, e.PydTransdate, e.PydWorkperiod, e.PytItemcode, e.OrdHdrnumber, e.PsdNumber }, "ix_pyd_asgn_id_type_num_stat");

            entity.HasIndex(e => e.PydCarinvnum, "ix_pyd_carinvnum").HasFillFactor(80);

            entity.HasIndex(e => new { e.PyhNumber, e.PydPretax, e.PydStatus, e.PydAmount, e.PydMinus }, "ix_pyd_collect_paydetails");

            entity.HasIndex(e => new { e.PydRefnumtype, e.PydRefnum }, "paydetail_refnums");

            entity.HasIndex(e => new { e.PydRefnum, e.PydRefnumtype, e.LghNumber }, "sk_pyd_refnum_refnumtype_lghnum");

            entity.HasIndex(e => new { e.PyhNumber, e.PydNumber }, "uk_pyh_pyd").IsUnique();

            entity.Property(e => e.PydNumber)
                .ValueGeneratedNever()
                .HasColumnName("pyd_number");
            entity.Property(e => e.AsgnId)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("asgn_id");
            entity.Property(e => e.AsgnNumber).HasColumnName("asgn_number");
            entity.Property(e => e.AsgnType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("asgn_type");
            entity.Property(e => e.BillOverride)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("bill_override");
            entity.Property(e => e.CacId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cac_id");
            entity.Property(e => e.CccId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ccc_id");
            entity.Property(e => e.ChtItemcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cht_itemcode");
            entity.Property(e => e.CrdCardnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("crd_cardnumber");
            entity.Property(e => e.DwTimestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("dw_timestamp");
            entity.Property(e => e.ExcludeGuaranteePay).HasDefaultValue(false);
            entity.Property(e => e.IvdNumber).HasColumnName("ivd_number");
            entity.Property(e => e.IvdPayrevenue)
                .HasColumnType("money")
                .HasColumnName("ivd_payrevenue");
            entity.Property(e => e.LghEndcity).HasColumnName("lgh_endcity");
            entity.Property(e => e.LghEndpoint)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_endpoint");
            entity.Property(e => e.LghNumber).HasColumnName("lgh_number");
            entity.Property(e => e.LghStartcity).HasColumnName("lgh_startcity");
            entity.Property(e => e.LghStartpoint)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("lgh_startpoint");
            entity.Property(e => e.MovNumber).HasColumnName("mov_number");
            entity.Property(e => e.NotBilledReason)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("not_billed_reason");
            entity.Property(e => e.OrdHdrnumber).HasColumnName("ord_hdrnumber");
            entity.Property(e => e.PayScheduleId).HasDefaultValue(0);
            entity.Property(e => e.PsdBatchId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("psd_batch_id");
            entity.Property(e => e.PsdId).HasColumnName("psd_id");
            entity.Property(e => e.PsdNumber).HasColumnName("psd_number");
            entity.Property(e => e.PydAdjFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_adj_flag");
            entity.Property(e => e.PydAdvstdnum).HasColumnName("pyd_advstdnum");
            entity.Property(e => e.PydAmount)
                .HasColumnType("money")
                .HasColumnName("pyd_amount");
            entity.Property(e => e.PydApCheckAmount)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("pyd_ap_check_amount");
            entity.Property(e => e.PydApCheckDate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_ap_check_date");
            entity.Property(e => e.PydApCheckNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pyd_ap_check_number");
            entity.Property(e => e.PydApUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pyd_ap_updated_by");
            entity.Property(e => e.PydApVendorId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pyd_ap_vendor_id");
            entity.Property(e => e.PydApVoucherNbr)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("pyd_ap_voucher_nbr");
            entity.Property(e => e.PydAprvRjctComment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pyd__aprv_rjct_comment");
            entity.Property(e => e.PydAtdId).HasColumnName("pyd_atd_id");
            entity.Property(e => e.PydAuthcode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pyd_authcode");
            entity.Property(e => e.PydBasis)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_basis");
            entity.Property(e => e.PydBasisunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_basisunit");
            entity.Property(e => e.PydBilledweight).HasColumnName("pyd_billedweight");
            entity.Property(e => e.PydBilltypeChangereason)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_billtype_changereason");
            entity.Property(e => e.PydBranch)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("pyd_branch");
            entity.Property(e => e.PydBranchOverride)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("pyd_branch_override");
            entity.Property(e => e.PydCarinvdate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_carinvdate");
            entity.Property(e => e.PydCarinvnum)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pyd_carinvnum");
            entity.Property(e => e.PydCarrierinvoiceAprv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_carrierinvoice_aprv");
            entity.Property(e => e.PydCarrierinvoiceRjct)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_carrierinvoice_rjct");
            entity.Property(e => e.PydCexRate)
                .HasColumnType("money")
                .HasColumnName("pyd_cex_rate");
            entity.Property(e => e.PydClockEnd)
                .HasColumnType("datetime")
                .HasColumnName("pyd_clock_end");
            entity.Property(e => e.PydClockStart)
                .HasColumnType("datetime")
                .HasColumnName("pyd_clock_start");
            entity.Property(e => e.PydCoownerSplitAdj)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_coowner_split_adj");
            entity.Property(e => e.PydCoownerSplitPercent).HasColumnName("pyd_coowner_split_percent");
            entity.Property(e => e.PydCreatedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_createdby");
            entity.Property(e => e.PydCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("pyd_createdon");
            entity.Property(e => e.PydCreditPayFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_credit_pay_flag");
            entity.Property(e => e.PydCurrency)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_currency");
            entity.Property(e => e.PydCurrencydate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_currencydate");
            entity.Property(e => e.PydDelays)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_delays");
            entity.Property(e => e.PydDescription)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("pyd_description");
            entity.Property(e => e.PydExportstatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_exportstatus");
            entity.Property(e => e.PydExpresscode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pyd_expresscode");
            entity.Property(e => e.PydFixedAmount)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength()
                .HasColumnName("pyd_fixedAmount");
            entity.Property(e => e.PydFixedQty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_fixedQty");
            entity.Property(e => e.PydFixedRate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength()
                .HasColumnName("pyd_fixedRate");
            entity.Property(e => e.PydGlnum)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("pyd_glnum");
            entity.Property(e => e.PydGptrans)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_GPTrans");
            entity.Property(e => e.PydGrossamount)
                .HasColumnType("money")
                .HasColumnName("pyd_grossamount");
            entity.Property(e => e.PydGstAmount)
                .HasColumnType("money")
                .HasColumnName("pyd_gst_amount");
            entity.Property(e => e.PydGstFlag).HasColumnName("pyd_gst_flag");
            entity.Property(e => e.PydHourlypaydate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_hourlypaydate");
            entity.Property(e => e.PydIcoIvdNumberChild).HasColumnName("pyd_ico_ivd_number_child");
            entity.Property(e => e.PydIgnoreglreset)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_ignoreglreset");
            entity.Property(e => e.PydIsdefault)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_isdefault");
            entity.Property(e => e.PydIvhHdrnumber).HasColumnName("pyd_ivh_hdrnumber");
            entity.Property(e => e.PydLessrevenue)
                .HasColumnType("money")
                .HasColumnName("pyd_lessrevenue");
            entity.Property(e => e.PydLghtype1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_lghtype1");
            entity.Property(e => e.PydLoadstate)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_loadstate");
            entity.Property(e => e.PydMaxchargeUsed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_maxcharge_used");
            entity.Property(e => e.PydMaxquantityUsed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_maxquantity_used");
            entity.Property(e => e.PydMbtaxableamount)
                .HasColumnType("money")
                .HasColumnName("pyd_mbtaxableamount");
            entity.Property(e => e.PydMileagetable)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_mileagetable");
            entity.Property(e => e.PydMinPeriod)
                .HasColumnType("datetime")
                .HasColumnName("pyd_min_period");
            entity.Property(e => e.PydMinus).HasColumnName("pyd_minus");
            entity.Property(e => e.PydNttaxableamount)
                .HasColumnType("money")
                .HasColumnName("pyd_nttaxableamount");
            entity.Property(e => e.PydOffsetpayNumber).HasColumnName("pyd_offsetpay_number");
            entity.Property(e => e.PydOrigAmount)
                .HasColumnType("money")
                .HasColumnName("pyd_orig_amount");
            entity.Property(e => e.PydOrigCurrency)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_orig_currency");
            entity.Property(e => e.PydOverlimit)
                .HasColumnType("money")
                .HasColumnName("pyd_overlimit");
            entity.Property(e => e.PydPaidAmount)
                .HasColumnType("money")
                .HasColumnName("pyd_paid_amount");
            entity.Property(e => e.PydPaidIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_paid_indicator");
            entity.Property(e => e.PydPair).HasColumnName("pyd_pair");
            entity.Property(e => e.PydParentPydNumber).HasColumnName("pyd_parent_pyd_number");
            entity.Property(e => e.PydPaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_payment_date");
            entity.Property(e => e.PydPaymentDocNumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("pyd_payment_doc_number");
            entity.Property(e => e.PydPayrevenue)
                .HasColumnType("money")
                .HasColumnName("pyd_payrevenue");
            entity.Property(e => e.PydPayto)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("pyd_payto");
            entity.Property(e => e.PydPerdiemExceeded)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_perdiem_exceeded");
            entity.Property(e => e.PydPostProcSource).HasColumnName("pyd_PostProcSource");
            entity.Property(e => e.PydPretax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_pretax");
            entity.Property(e => e.PydProrap)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_prorap");
            entity.Property(e => e.PydQuantity).HasColumnName("pyd_quantity");
            entity.Property(e => e.PydRate)
                .HasColumnType("money")
                .HasColumnName("pyd_rate");
            entity.Property(e => e.PydRateFactor).HasColumnName("pyd_rate_factor");
            entity.Property(e => e.PydRateunit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_rateunit");
            entity.Property(e => e.PydReconcile).HasColumnName("pyd_reconcile");
            entity.Property(e => e.PydRefInvoice)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pyd_ref_invoice");
            entity.Property(e => e.PydRefInvoicedate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_ref_invoicedate");
            entity.Property(e => e.PydRefnum)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pyd_refnum");
            entity.Property(e => e.PydRefnumtype)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_refnumtype");
            entity.Property(e => e.PydRegTimePydnum).HasColumnName("pyd_reg_time_pydnum");
            entity.Property(e => e.PydRegTimeQty).HasColumnName("pyd_reg_time_qty");
            entity.Property(e => e.PydReleasedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_releasedby");
            entity.Property(e => e.PydRemarks)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("pyd_remarks");
            entity.Property(e => e.PydRemitToVendorId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("pyd_RemitToVendorID");
            entity.Property(e => e.PydReportQuantity)
                .HasColumnType("money")
                .HasColumnName("pyd_report_quantity");
            entity.Property(e => e.PydReportRate)
                .HasColumnType("money")
                .HasColumnName("pyd_report_rate");
            entity.Property(e => e.PydRevenueratio).HasColumnName("pyd_revenueratio");
            entity.Property(e => e.PydSequence).HasColumnName("pyd_sequence");
            entity.Property(e => e.PydSmwldId).HasColumnName("pyd_smwld_id");
            entity.Property(e => e.PydStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_status");
            entity.Property(e => e.PydTaxOriginatorPydNumber).HasColumnName("pyd_tax_originator_pyd_number");
            entity.Property(e => e.PydThirdpartySplitPercent).HasColumnName("pyd_thirdparty_split_percent");
            entity.Property(e => e.PydTotaladvanced)
                .HasColumnType("money")
                .HasColumnName("pyd_totaladvanced");
            entity.Property(e => e.PydTprdiffbtwNumber).HasColumnName("pyd_tprdiffbtw_number");
            entity.Property(e => e.PydTprsplitNumber).HasColumnName("pyd_tprsplit_number");
            entity.Property(e => e.PydTransdate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_transdate");
            entity.Property(e => e.PydTransferdate)
                .HasColumnType("datetime")
                .HasColumnName("pyd_transferdate");
            entity.Property(e => e.PydUnit)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyd_unit");
            entity.Property(e => e.PydUpdatedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_updatedby");
            entity.Property(e => e.PydUpdatedon)
                .HasColumnType("datetime")
                .HasColumnName("pyd_updatedon");
            entity.Property(e => e.PydUpdsrc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_updsrc");
            entity.Property(e => e.PydVendorpay)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyd_vendorpay");
            entity.Property(e => e.PydVendortopay)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .HasColumnName("pyd_vendortopay");
            entity.Property(e => e.PydWorkcycleDescription)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("pyd_workcycle_description");
            entity.Property(e => e.PydWorkcycleStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pyd_workcycle_status");
            entity.Property(e => e.PydWorkperiod)
                .HasColumnType("datetime")
                .HasColumnName("pyd_workperiod");
            entity.Property(e => e.PydXrefnumber).HasColumnName("pyd_xrefnumber");
            entity.Property(e => e.PyhNumber).HasColumnName("pyh_number");
            entity.Property(e => e.PyhPayperiod)
                .HasColumnType("datetime")
                .HasColumnName("pyh_payperiod");
            entity.Property(e => e.PyrRatecode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyr_ratecode");
            entity.Property(e => e.PytFee1)
                .HasColumnType("money")
                .HasColumnName("pyt_fee1");
            entity.Property(e => e.PytFee2)
                .HasColumnType("money")
                .HasColumnName("pyt_fee2");
            entity.Property(e => e.PytItemcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pyt_itemcode");
            entity.Property(e => e.PytOtflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pyt_otflag");
            entity.Property(e => e.StdNumber).HasColumnName("std_number");
            entity.Property(e => e.StdNumberAdj).HasColumnName("std_number_adj");
            entity.Property(e => e.StdPurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("std_purchase_date");
            entity.Property(e => e.StdPurchaseTaxState)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("std_purchase_tax_state");
            entity.Property(e => e.StpMfhSequence).HasColumnName("stp_mfh_sequence");
            entity.Property(e => e.StpNumber).HasColumnName("stp_number");
            entity.Property(e => e.StpNumberPacos).HasColumnName("stp_number_pacos");
            entity.Property(e => e.TarTarriffnumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("tar_tarriffnumber");
            entity.Property(e => e.TermCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("termCode");
            entity.Property(e => e.Timestamp)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("timestamp");
        });
        modelBuilder.HasSequence<int>("TransferHeaderSEQ").HasMin(1L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
