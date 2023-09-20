using System;
using System.Collections.Generic;

namespace FuelMachine.Models;

public partial class CarModel
{
    public int Id { get; set; }

    public string ModelName { get; set; } = null!;

    public int CarId { get; set; }

    public int PowerInKw { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual ICollection<ModelConsumption> ModelConsumptions { get; set; } = new List<ModelConsumption>();
}
