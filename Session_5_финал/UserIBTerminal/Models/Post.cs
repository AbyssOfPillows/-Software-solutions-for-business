using System;
using System.Collections.Generic;

namespace UserIBTerminal.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
