using System;
using System.Collections.Generic;

namespace FuelMachine.Models;

public partial class Town
{
    public int Id { get; set; }

    public string TownName { get; set; } = null!;

    public int Coefficient { get; set; }
}
