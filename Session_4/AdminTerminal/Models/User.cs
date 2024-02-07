using System;
using System.Collections.Generic;

namespace AdminTerminal.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patryonomic { get; set; }

    public string? Sex { get; set; }

    public int? PostId { get; set; }

    public int? TypeId { get; set; }

    public string? SecretWord { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public bool? True { get; set; }

    public virtual Post? Post { get; set; }

    public virtual Type? Type { get; set; }
}
