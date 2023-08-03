using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class MainStopReason
{
    public int StopReasonId { get; set; }

    public string? StopReason { get; set; }

    public string? StopReasonType { get; set; }

    public virtual ICollection<SubStopReason> SubStopReasons { get; set; } = new List<SubStopReason>();
}
