using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string? ShiftType { get; set; }

    public DateTime? ShiftStartTime { get; set; }

    public DateTime? ShiftEndTime { get; set; }

    public virtual ICollection<Counting> Countings { get; set; } = new List<Counting>();
}
