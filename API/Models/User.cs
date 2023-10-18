using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public string? Login { get; set; }

    public string? EMail { get; set; }

    public string? Password { get; set; }

    public int Id { get; set; }
}
