using System;
using System.Collections.Generic;

namespace FuelMachine.Models;

public partial class Fuel
{
    public int Id { get; set; }

    public string FuelType { get; set; } = null!;

    public int Coefficient { get; set; }
}
