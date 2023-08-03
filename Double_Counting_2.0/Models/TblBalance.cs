using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class TblBalance
{
    public int BalanceId { get; set; }

    public int OscounterId { get; set; }

    public DateTime StartOfBalance { get; set; }

    public DateTime EndOfBalance { get; set; }

    public int TargetQty { get; set; }

    public int QtyBanknoteSheet { get; set; }

    public int QtyNotasaveSheet { get; set; }

    public int QtyNotPrintedSheet { get; set; }

    public int QtyProductionPiles { get; set; }

    public decimal NetplanNo { get; set; }

    public string BatchNo { get; set; } = null!;

    public virtual TblCounter Oscounter { get; set; } = null!;
}
