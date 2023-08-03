using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class TblCounter
{
    public int CounterId { get; set; }

    public int SheetCounter { get; set; }

    public DateTime TimestampPrinting { get; set; }

    public decimal PrintingSpeed { get; set; }

    public string SheetType { get; set; } = null!;

    public int SortingPile { get; set; }

    public string SensorResults { get; set; } = null!;

    public string SheetRating { get; set; } = null!;
    public int Pile01 { get; set; }
    public int Pile02 { get; set; }

    public int Pile03 { get; set; }

    public virtual ICollection<TblBalance> TblBalances { get; set; } = new List<TblBalance>();
}
