using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Group
{
    public int Id { get; set; }

    public int? Appointment { get; set; }

    public string? GroupNumber { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Appointment? AppointmentNavigation { get; set; }
}
