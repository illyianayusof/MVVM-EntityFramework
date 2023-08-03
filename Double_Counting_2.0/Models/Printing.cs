using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class Printing
{
    public int PrintingId { get; set; }

    public string? BatchNumber { get; set; }

    public int? WasteBeforeId { get; set; }

    public int? WasteAfterId { get; set; }

    public int? WasteTotal { get; set; }

    public int? InspectionTotal { get; set; }

    public int? NotasaveError { get; set; }

    public string? Balanced { get; set; }

    public int? Didiff { get; set; }

    public virtual WasteBefore Printing1 { get; set; } = null!;

    public virtual WasteAfter PrintingNavigation { get; set; } = null!;
}
