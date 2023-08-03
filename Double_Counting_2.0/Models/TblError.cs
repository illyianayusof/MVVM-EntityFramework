using System;
using System.Collections.Generic;

namespace Double_Counting_2._0.Models;

public partial class TblError
{
    public int ErrorId { get; set; }

    public DateTime ErrorTimestamp { get; set; }

    public string ErrorMessage { get; set; } = null!;
}
