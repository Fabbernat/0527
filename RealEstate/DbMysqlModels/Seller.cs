using System;
using System.Collections.Generic;

namespace RealEstate.DbMysqlModels;

public partial class Seller
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Realestate> Realestates { get; set; } = new List<Realestate>();
}
