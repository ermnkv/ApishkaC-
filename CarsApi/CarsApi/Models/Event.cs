using System;
using System.Collections.Generic;

namespace CarsApi.Models;

public partial class Event
{
    public long IdUser { get; set; }

    public long IdEvent { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
