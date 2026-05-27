using System;
using System.Collections.Generic;

namespace Fábián_Bernát_backend.DbModels;

public partial class Ingatlanok
{
    public int Id { get; set; }

    public int Kategoria { get; set; }

    public string Leiras { get; set; } = null!;

    public DateOnly HirdetesDatuma { get; set; }

    public bool Tehermentes { get; set; }

    public int Ar { get; set; }

    public string KepUrl { get; set; } = null!;

    public virtual Kategoria KategoriaNavigation { get; set; } = null!;
}
