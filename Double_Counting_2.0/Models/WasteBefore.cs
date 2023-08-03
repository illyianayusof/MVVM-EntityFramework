using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class WasteBefore
{
    public int WasteBeforeId { get; set; }

    public int? BatchNumberId { get; set; }

    public int? WasteBeforeAmount { get; set; }

    public virtual ICollection<Counting> Countings { get; set; } = new List<Counting>();

    public virtual Printing? Printing { get; set; }
}
