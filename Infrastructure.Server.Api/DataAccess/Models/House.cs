using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class House
{
    public long Id { get; set; }

    public string OrdinalNumber { get; set; } = null!;

    public DateOnly? BuildingYear { get; set; }

    public short Material { get; set; }

    public bool IsHistoric { get; set; }

    public DateOnly? RenovationYear { get; set; }

    public long? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<BuildLog> BuildLogs { get; set; } = new List<BuildLog>();

    public virtual ICollection<Entrance> Entrances { get; set; } = new List<Entrance>();
}
