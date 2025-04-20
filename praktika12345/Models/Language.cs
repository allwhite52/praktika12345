using System;
using System.Collections.Generic;

namespace praktika12345.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public string LanguageGroup { get; set; } = null!;

    public string LanguageSystem { get; set; } = null!;

    public virtual ICollection<Squad> Squads { get; set; } = new List<Squad>();
}
