using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class ProcessUnit
{
    public int ProcessUnitId { get; set; }

    public string? ProcessUnitName { get; set; }

    public int? ProcessTypeId { get; set; }

    public string? InventoryName { get; set; }

    public int? CumM { get; set; }

    public int? PerdayM { get; set; }

    public int? TotalM { get; set; }

    public virtual ProcessType? ProcessType { get; set; }
}
