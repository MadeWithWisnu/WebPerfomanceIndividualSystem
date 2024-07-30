using System;
using System.Collections.Generic;

namespace PerformanceIndividualDataAccess.Models;

public partial class Indicator
{
    public int Id { get; set; }

    public int? Additionalindicator { get; set; }

    public string? IndicatorName { get; set; }

    public string? IndicatorType { get; set; }

    public int? Value { get; set; }

    public virtual Additionalindicator? AdditionalindicatorNavigation { get; set; }
}
