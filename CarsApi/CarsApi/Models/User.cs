using System;
using System.Collections.Generic;

namespace CarsApi.Models;

public partial class User
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Channel> Channels { get; set; } = new List<Channel>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();

    public virtual ICollection<Channel> IdChannels { get; set; } = new List<Channel>();

    public virtual ICollection<Trip> IdTrips { get; set; } = new List<Trip>();

    public virtual ICollection<Post> LikePosts { get; set; } = new List<Post>();
}
