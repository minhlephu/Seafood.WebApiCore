using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class ProdInfo : AbstractModel
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string Description { get; set; } = null!;

    public string? Note { get; set; }
}
