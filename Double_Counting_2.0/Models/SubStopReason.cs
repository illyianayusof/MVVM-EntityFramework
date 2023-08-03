using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class SubStopReason
{
    public int SubStopReasonId { get; set; }

    public string SubStopReason1 { get; set; } = null!;

    public int MainStopReasonId { get; set; }

    public virtual MainStopReason MainStopReason { get; set; } = null!;
}
