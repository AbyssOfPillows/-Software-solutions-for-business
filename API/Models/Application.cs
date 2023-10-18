using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Application
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string PasportDetails { get; set; } = null!;

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? GroupId { get; set; }

    public bool? Approved { get; set; }

    public string? Reason { get; set; }

    public bool? Visited { get; set; }

    public string TypeApplication { get; set; } = null!;

    public DateTime? TheDesiredStartOfTheActionOfTheApplication { get; set; }

    public DateTime? TheDesiredEndOfTheActionOfTheApplication { get; set; }

    public string Note { get; set; } = null!;

    public string Organization { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public byte[]? PassportScan { get; set; }

    public string? DepartureTime { get; set; }

    public virtual Group? Group { get; set; }
}
