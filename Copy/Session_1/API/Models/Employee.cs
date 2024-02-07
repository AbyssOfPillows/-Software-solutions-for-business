using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Employee
{
    public int Code { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Departament Department { get; set; } = null!;
}
