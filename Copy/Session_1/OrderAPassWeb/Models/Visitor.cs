using System;
using System.Collections.Generic;

namespace Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string? NumberPhone { get; set; }

    public string EMail { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int PasportNumber { get; set; }

    public int PasportSeria { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
