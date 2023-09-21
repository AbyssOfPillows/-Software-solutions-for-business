using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Group
{
    public int Id { get; set; }

    public int? Appointment { get; set; }

    public string? GroupNumber { get; set; }

    public virtual Appointment? AppointmentNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
