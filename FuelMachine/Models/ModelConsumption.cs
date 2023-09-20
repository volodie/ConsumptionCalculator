using System;
using System.Collections.Generic;

namespace FuelMachine.Models;

public partial class ModelConsumption
{
    public int Id { get; set; }

    public int ModelId { get; set; }

    public decimal VechicleConsumption { get; set; }

    public virtual CarModel Model { get; set; } = null!;
}
