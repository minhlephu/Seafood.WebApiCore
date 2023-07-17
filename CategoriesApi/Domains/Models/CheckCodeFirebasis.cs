using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class CheckCodeFirebasis : AbstractModel
{
    public Guid Id { get; set; }

    public string Mobile { get; set; } = null!;

    public DateTime TimeSend { get; set; }

    public int NumberOfSend { get; set; }

    public string? LatestCode { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }
}
