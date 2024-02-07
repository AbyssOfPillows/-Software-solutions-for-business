using System;
using System.Collections.Generic;

namespace Models;

public partial class GroupsVisitor
{
    public int GroupId { get; set; }

    public int VisitorId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Visitor Visitor { get; set; } = null!;
}
