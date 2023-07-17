using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class Region : AbstractModel
{
    public Guid Id { get; set; }

    public string? NameRegion { get; set; }

    public string? CodeRegion { get; set; }

    public string? NameDistrict { get; set; }

    public string? CodeDistrict { get; set; }

    public string? NameWard { get; set; }

    public string? CodeWard { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }
}
