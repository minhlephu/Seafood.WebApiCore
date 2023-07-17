using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class ProdProcessing : AbstractModel
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Note { get; set; }
}
