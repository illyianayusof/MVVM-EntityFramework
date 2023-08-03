using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class ProcessType
{
    public int ProcessTypeId { get; set; }

    public string? ProcessTypeName { get; set; }

    public virtual ICollection<ProcessUnit> ProcessUnits { get; set; } = new List<ProcessUnit>();
}
