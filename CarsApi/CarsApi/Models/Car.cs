using System;
using System.Collections.Generic;

namespace CarsApi.Models;

public partial class Car
{
    public long Id { get; set; }

    public long IdCar { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
