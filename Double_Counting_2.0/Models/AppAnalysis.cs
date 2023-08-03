using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class AppAnalysis
{
    public int AppAnalysisId { get; set; }

    public string? AppMode { get; set; }

    public DateTime? AppStartTime { get; set; }

    public DateTime? AppEndTime { get; set; }
}
