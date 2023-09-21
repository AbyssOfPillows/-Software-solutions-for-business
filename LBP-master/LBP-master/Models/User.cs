using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EMail { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PasportDetails { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Appointment { get; set; }

    public virtual Group? AppointmentNavigation { get; set; }
}
