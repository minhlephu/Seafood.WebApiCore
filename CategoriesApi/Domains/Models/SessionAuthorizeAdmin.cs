using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class SessionAuthorizeAdmin : AbstractModel
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string? IpRequest { get; set; }

    public string? Session { get; set; }

    public string? SessionId { get; set; }

    public DateTime TimeLogin { get; set; }

    public DateTime? TimeLogout { get; set; }
}
