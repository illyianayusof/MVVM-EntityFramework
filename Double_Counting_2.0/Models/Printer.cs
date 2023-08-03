using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class Printer
{
    public int PinterId { get; set; }

    public string? PrinterName { get; set; }

    public DateTime? LastLoggedIn { get; set; }

    public virtual ICollection<Counting> Countings { get; set; } = new List<Counting>();
}
