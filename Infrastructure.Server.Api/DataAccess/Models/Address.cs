using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Address
{
    public long Id { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<House> Houses { get; set; } = new List<House>();
}
