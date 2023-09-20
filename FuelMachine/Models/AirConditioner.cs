using System;
using System.Collections.Generic;

namespace FuelMachine.Models;

public partial class AirConditioner
{
    public int Id { get; set; }

    public bool IsAirConditionerPresent { get; set; }

    public int Coefficient { get; set; }
}
