using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public string? DateOfVisit { get; set; }

    public int? ToWhomId { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual Employe? ToWhom { get; set; }
}
