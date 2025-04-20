using System;
using System.Collections.Generic;

namespace praktika12345.Models;

public partial class Squad
{
    public int SquadsId { get; set; }

    public int? CountryId { get; set; }

    public int? LanguageId { get; set; }

    public long SpeakersCount { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Language? Language { get; set; }
}
