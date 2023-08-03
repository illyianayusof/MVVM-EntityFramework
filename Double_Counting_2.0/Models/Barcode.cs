using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class Barcode
{
    public int BarcodeId { get; set; }

    public string? BatchNumber { get; set; }

    public DateTime? ScannedTime { get; set; }

    public int? FkDenoProfileId { get; set; }

    public virtual DenoProfile? FkDenoProfile { get; set; }
}
