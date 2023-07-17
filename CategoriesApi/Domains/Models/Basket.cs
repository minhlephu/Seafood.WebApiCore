using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class Basket : AbstractModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public Guid ProdProcessingId { get; set; }

    public string? Note { get; set; }
}
