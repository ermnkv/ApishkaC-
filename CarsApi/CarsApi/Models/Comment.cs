using System;
using System.Collections.Generic;

namespace CarsApi.Models;

public partial class Comment
{
    public long Id { get; set; }

    public long IdCom { get; set; }

    public long ComPost { get; set; }

    public string Content { get; set; } = null!;

    public virtual Post ComPostNavigation { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
