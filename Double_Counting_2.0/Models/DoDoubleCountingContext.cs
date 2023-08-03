using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Double_Counting_2._0.Models;

public partial class DoDoubleCountingContext : DbContext
{
    public DoDoubleCountingContext()
    {
    }

    public DoDoubleCountingContext(DbContextOptions<DoDoubleCountingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppAnalysis> AppAnalyses { get; set; }

    public virtual DbSet<Barcode> Barcodes { get; set; }

    public virtual DbSet<Counting> Countings { get; set; }

    public virtual DbSet<DenoProfile> DenoProfiles { get; set; }

    public virtual DbSet<MainStopReason> MainStopReasons { get; set; }

    public virtual DbSet<Printer> Printers { get; set; }

    public virtual DbSet<Printing> Printings { get; set; }

    public virtual DbSet<ProcessType> ProcessTypes { get; set; }

    public virtual DbSet<ProcessUnit> ProcessUnits { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<SubStopReason> SubStopReasons { get; set; }

    public virtual DbSet<TblBalance> TblBalances { get; set; }

    public virtual DbSet<TblCounter> TblCounters { get; set; }

    public virtual DbSet<TblError> TblErrors { get; set; }

    public virtual DbSet<WasteAfter> WasteAfters { get; set; }

    public virtual DbSet<WasteBefore> WasteBefores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HDBEK6R\\SQLEXPRESS;Database=DO_Double_Counting;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppAnalysis>(entity =>
        {
            entity.ToTable("AppAnalysis");

            entity.Property(e => e.AppAnalysisId).HasColumnName("AppAnalysisID");
            entity.Property(e => e.AppMode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Barcode>(entity =>
        {
            entity.ToTable("Barcode");

            entity.Property(e => e.BarcodeId).HasColumnName("BarcodeID");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkDenoProfileId).HasColumnName("FK_DenoProfileID");

            entity.HasOne(d => d.FkDenoProfile).WithMany(p => p.Barcodes)
                .HasForeignKey(d => d.FkDenoProfileId)
                .HasConstraintName("FK_Barcode_DenoProfile");
        });

        modelBuilder.Entity<Counting>(entity =>
        {
            entity.ToTable("Counting");

            entity.Property(e => e.Balanced)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DenoProfileId).HasColumnName("DenoProfileID");
            entity.Property(e => e.Didiff).HasColumnName("DIDiff");
            entity.Property(e => e.Direason)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DIReason");
            entity.Property(e => e.IntaglioOrientation)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Machine)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MachineId).HasColumnName("MachineID");
            entity.Property(e => e.PinterId).HasColumnName("PinterID");
            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            entity.Property(e => e.WasteAfterId).HasColumnName("WasteAfterID");
            entity.Property(e => e.WasteBeforeId).HasColumnName("WasteBeforeID");

            entity.HasOne(d => d.DenoProfile).WithMany(p => p.Countings)
                .HasForeignKey(d => d.DenoProfileId)
                .HasConstraintName("FK_Counting_DenoProfile");

            entity.HasOne(d => d.Pinter).WithMany(p => p.Countings)
                .HasForeignKey(d => d.PinterId)
                .HasConstraintName("FK_Counting_Printer");

            entity.HasOne(d => d.Shift).WithMany(p => p.Countings)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK_Counting_Shift");

            entity.HasOne(d => d.WasteAfter).WithMany(p => p.Countings)
                .HasForeignKey(d => d.WasteAfterId)
                .HasConstraintName("FK_Counting_WasteAfter");

            entity.HasOne(d => d.WasteBefore).WithMany(p => p.Countings)
                .HasForeignKey(d => d.WasteBeforeId)
                .HasConstraintName("FK_Counting_WasteBefore");
        });

        modelBuilder.Entity<DenoProfile>(entity =>
        {
            entity.ToTable("DenoProfile");

            entity.Property(e => e.DenoProfileId).HasColumnName("DenoProfileID");
            entity.Property(e => e.DenoProfile1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DenoProfile");
            entity.Property(e => e.NetworkNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MainStopReason>(entity =>
        {
            entity.HasKey(e => e.StopReasonId);

            entity.ToTable("MainStopReason");

            entity.Property(e => e.StopReasonId)
                .ValueGeneratedNever()
                .HasColumnName("StopReasonID");
            entity.Property(e => e.StopReason)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StopReasonType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Printer>(entity =>
        {
            entity.HasKey(e => e.PinterId);

            entity.ToTable("Printer");

            entity.Property(e => e.PinterId)
                .ValueGeneratedNever()
                .HasColumnName("PinterID");
            entity.Property(e => e.PrinterName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Printing>(entity =>
        {
            entity.ToTable("Printing");

            entity.Property(e => e.PrintingId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PrintingID");
            entity.Property(e => e.Balanced)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Didiff).HasColumnName("DIDiff");
            entity.Property(e => e.WasteAfterId).HasColumnName("WasteAfterID");
            entity.Property(e => e.WasteBeforeId).HasColumnName("WasteBeforeID");

            entity.HasOne(d => d.PrintingNavigation).WithOne(p => p.Printing)
                .HasForeignKey<Printing>(d => d.PrintingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Printing_WasteAfter");

            entity.HasOne(d => d.Printing1).WithOne(p => p.Printing)
                .HasForeignKey<Printing>(d => d.PrintingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Printing_WasteBefore");
        });

        modelBuilder.Entity<ProcessType>(entity =>
        {
            entity.ToTable("ProcessType");

            entity.Property(e => e.ProcessTypeId).HasColumnName("ProcessTypeID");
            entity.Property(e => e.ProcessTypeName)
                .HasMaxLength(520)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProcessUnit>(entity =>
        {
            entity.ToTable("ProcessUnit");

            entity.Property(e => e.ProcessUnitId).HasColumnName("ProcessUnitID");
            entity.Property(e => e.InventoryName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProcessTypeId).HasColumnName("ProcessTypeID");
            entity.Property(e => e.ProcessUnitName)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.ProcessType).WithMany(p => p.ProcessUnits)
                .HasForeignKey(d => d.ProcessTypeId)
                .HasConstraintName("FK_ProcessUnit_ProcessType");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("Shift");

            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            entity.Property(e => e.ShiftType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubStopReason>(entity =>
        {
            entity.ToTable("SubStopReason");

            entity.Property(e => e.SubStopReasonId).HasColumnName("SubStopReasonID");
            entity.Property(e => e.MainStopReasonId).HasColumnName("MainStopReasonID");
            entity.Property(e => e.SubStopReason1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SubStopReason");

            entity.HasOne(d => d.MainStopReason).WithMany(p => p.SubStopReasons)
                .HasForeignKey(d => d.MainStopReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubStopReason_MainStopReason");
        });

        modelBuilder.Entity<TblBalance>(entity =>
        {
            entity.HasKey(e => e.BalanceId);

            entity.ToTable("tblBalance");

            entity.Property(e => e.BatchNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NetplanNo).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.OscounterId).HasColumnName("OSCounterId");

            entity.HasOne(d => d.Oscounter).WithMany(p => p.TblBalances)
                .HasForeignKey(d => d.OscounterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBalance_tblCounter");
        });

        modelBuilder.Entity<TblCounter>(entity =>
        {
            entity.HasKey(e => e.CounterId);

            entity.ToTable("tblCounter");

            entity.Property(e => e.PrintingSpeed).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SensorResults)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SheetRating)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SheetType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblError>(entity =>
        {
            entity.HasKey(e => e.ErrorId);

            entity.ToTable("tblError");

            entity.Property(e => e.ErrorMessage).IsUnicode(false);
        });

        modelBuilder.Entity<WasteAfter>(entity =>
        {
            entity.ToTable("WasteAfter");

            entity.Property(e => e.WasteAfterId).HasColumnName("WasteAfterID");
            entity.Property(e => e.BatchNumberId).HasColumnName("BatchNumberID");
        });

        modelBuilder.Entity<WasteBefore>(entity =>
        {
            entity.ToTable("WasteBefore");

            entity.Property(e => e.WasteBeforeId).HasColumnName("WasteBeforeID");
            entity.Property(e => e.BatchNumberId).HasColumnName("BatchNumberID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
