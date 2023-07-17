using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class SessionAuthorize : AbstractModel
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string? IpRequest { get; set; }

    public string Session { get; set; } = null!;

    public string SessionId { get; set; } = null!;
}
