using System;
using System.Collections.Generic;

namespace CarManager.Models.Store;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public string Segment { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; }= new List<Model>();
}
