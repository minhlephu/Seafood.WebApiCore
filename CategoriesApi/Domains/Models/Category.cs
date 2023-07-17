using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class Category : AbstractModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public string? Code { get; set; }

    public string? Icon { get; set; }
}
