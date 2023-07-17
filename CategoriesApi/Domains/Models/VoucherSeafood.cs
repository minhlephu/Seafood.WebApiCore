using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class VoucherSeafood : AbstractModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int TypeVoucher { get; set; }

    public int ReductionAmount { get; set; }

    public string Code { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? ConditionsApply { get; set; }

    public string? Note { get; set; }
}
