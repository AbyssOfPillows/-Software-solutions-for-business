using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Departament
{
    public int Id { get; set; }

    public string? Departament1 { get; set; }

    public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();
}
