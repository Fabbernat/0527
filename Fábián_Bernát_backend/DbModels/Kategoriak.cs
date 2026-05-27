using System;
using System.Collections.Generic;

namespace Fábián_Bernát_backend.DbModels;

public partial class Kategoriak
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public virtual ICollection<Ingatlanok> Ingatlanoks { get; set; } = new List<Ingatlanok>();
}
