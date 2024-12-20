using System;
using System.Collections.Generic;

namespace CarsApi.Models;

public partial class Channel
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long OwnerId { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
