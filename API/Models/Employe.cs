using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Employe
{
    public int EmployeeCode { get; set; }

    public int Departament { get; set; }

    public string Fio { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Departament DepartamentNavigation { get; set; } = null!;
}
