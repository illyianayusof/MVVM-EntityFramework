using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class Counting
{
    public int CountingId { get; set; }

    public DateTime? Date { get; set; }

    public string? Machine { get; set; }

    public int? BatchNo { get; set; }

    public int? InspectionTotal { get; set; }

    public int? WasteBeforeId { get; set; }

    public int? WasteAfterId { get; set; }

    public int? WasteTotal { get; set; }

    public int? SheetsRerun { get; set; }

    public int? NotasaveError { get; set; }

    public int? Total { get; set; }

    public string? Balanced { get; set; }

    public string? Direason { get; set; }

    public int? Didiff { get; set; }

    public int? NotasavePercentage { get; set; }

    public string? IntaglioOrientation { get; set; }

    public int? ShiftId { get; set; }

    public int? DenoProfileId { get; set; }

    public int? PinterId { get; set; }

    public int? MachineId { get; set; }

    public virtual DenoProfile? DenoProfile { get; set; }

    public virtual Printer? Pinter { get; set; }

    public virtual Shift? Shift { get; set; }

    public virtual WasteAfter? WasteAfter { get; set; }

    public virtual WasteBefore? WasteBefore { get; set; }
}
