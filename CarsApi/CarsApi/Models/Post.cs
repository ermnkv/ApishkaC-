using System;
using System.Collections.Generic;

namespace CarsApi.Models;

public partial class Post
{
    public long Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public string Title { get; set; } = null!;

    public long ChannelId { get; set; }

    public virtual Channel Channel { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<User> Ids { get; set; } = new List<User>();
}
