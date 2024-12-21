using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Entrance
{
    public long Id { get; set; }

    public string Position { get; set; } = null!;

    public bool HasElevator { get; set; }

    public bool HasAccessControl { get; set; }

    public string? Description { get; set; }

    public long HouseId { get; set; }

    public virtual ICollection<Flat> Flats { get; set; } = new List<Flat>();

    public virtual House House { get; set; } = null!;
}
