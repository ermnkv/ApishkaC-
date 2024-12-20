using System;
using System.Collections.Generic;

namespace CarsApi.Models;

public partial class Trip
{
    public long IdTrip { get; set; }

    public long IdUser { get; set; }

    public DateTime StartData { get; set; }

    public DateTime EndData { get; set; }

    public string Description { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
