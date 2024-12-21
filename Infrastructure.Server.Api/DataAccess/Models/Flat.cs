using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Flat
{
    public long Id { get; set; }

    public short Size { get; set; }

    public bool HasBalcony { get; set; }

    public bool HasParkingSpace { get; set; }

    public bool IsRented { get; set; }

    public long EntranceId { get; set; }

    public virtual Entrance Entrance { get; set; } = null!;
}
