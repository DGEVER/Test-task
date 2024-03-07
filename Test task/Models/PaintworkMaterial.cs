using System;
using System.Collections.Generic;

namespace Test_task.Models;

public partial class PaintworkMaterial
{
    public Guid Id { get; set; }

    public string NameMaterial { get; set; } = null!;

    public string ItemNumber { get; set; } = null!;

    public string TypeMaterial { get; set; } = null!;

    public float SpecificWeight { get; set; }

    public float ContainerVolume { get; set; }

    public float WeightWithMaterial { get; set; }

    public string Brand { get; set; } = null!;
}
