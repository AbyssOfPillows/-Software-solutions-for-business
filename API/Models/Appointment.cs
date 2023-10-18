using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public string? DateOfVisit { get; set; }

    public int EmployeId { get; set; }

    public string? TimeOfVisit { get; set; }

    public virtual Employe Employe { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
