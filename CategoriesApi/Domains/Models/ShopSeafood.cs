using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class ShopSeafood : AbstractModel
{
    public Guid Id { get; set; }

    public string CodeRegion { get; set; } = null!;

    public string CodeDistrict { get; set; } = null!;

    public string CodeWard { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int TypeAddress { get; set; }

    public string Mobile { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Note { get; set; }
}
