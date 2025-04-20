using System;
using System.Collections.Generic;

namespace praktika12345.Models;

public partial class User
{
    public int UsersId { get; set; }

    public string UserRole { get; set; } = null!;

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
}
