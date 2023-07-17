using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class ProdPromotion : AbstractModel
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? Content { get; set; }

    public bool? PromotionMain { get; set; }

    public string? Note { get; set; }
}
