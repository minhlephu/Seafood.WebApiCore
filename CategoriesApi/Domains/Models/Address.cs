using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class Address : AbstractModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string CodeRegion { get; set; } = null!;

    public string CodeDistrict { get; set; } = null!;

    public string CodeWard { get; set; } = null!;

    public int TypeAddress { get; set; }

    public int TypeAddressDetail { get; set; }

    public bool IsAddressMain { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Note { get; set; }
}
