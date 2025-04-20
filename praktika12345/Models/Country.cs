using System;
using System.Collections.Generic;

namespace praktika12345.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string Capital { get; set; } = null!;

    public string Continent { get; set; } = null!;

    public long Populations { get; set; }

    public virtual ICollection<Squad> Squads { get; set; } = new List<Squad>();
}
