using System;
using System.Collections.Generic;

namespace FuelMachine.Models;

public partial class Car
{
    public int Id { get; set; }

    public string CarName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
