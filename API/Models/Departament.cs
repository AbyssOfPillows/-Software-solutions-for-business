using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Departament
{
    public int Id { get; set; }

    public string Departament1 { get; set; } = null!;

    public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();
}
