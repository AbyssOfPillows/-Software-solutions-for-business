using System;
using System.Collections.Generic;

namespace Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}
