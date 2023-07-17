using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class SeafoodPromotion : AbstractModel
{
    public Guid Id { get; set; }

    public string? ShopCode { get; set; }

    public string? Content { get; set; }

    public string? Note { get; set; }
}
