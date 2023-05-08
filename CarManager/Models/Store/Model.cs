using System;
using System.Collections.Generic;

namespace CarManager.Models.Store;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int CompanyId { get; set; }

    public virtual Company? Company { get; set; } = null!;
}
