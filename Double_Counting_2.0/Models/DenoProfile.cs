using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class DenoProfile
{
    public int DenoProfileId { get; set; }

    public string? DenoProfile1 { get; set; }

    public string? NetworkNumber { get; set; }

    public virtual ICollection<Barcode> Barcodes { get; set; } = new List<Barcode>();

    public virtual ICollection<Counting> Countings { get; set; } = new List<Counting>();
}
