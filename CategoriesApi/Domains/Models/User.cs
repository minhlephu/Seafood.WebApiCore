using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class User : AbstractModel
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Avarta { get; set; }

    public DateTime? Birthday { get; set; }

    public int? Sex { get; set; }

    public string Mobile { get; set; } = null!;

    public string? Email { get; set; }

    public string? Company { get; set; }

    public string? Roles { get; set; }

    public bool? IsAdminUser { get; set; }

    public bool? IsLocked { get; set; }

    public string? Session { get; set; }

    public string? SessionId { get; set; }
}
