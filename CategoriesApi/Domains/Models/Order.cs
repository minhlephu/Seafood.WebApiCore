﻿using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class Order : AbstractModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public Guid ProdProcessingId { get; set; }

    public Guid AddressId { get; set; }

    public int TypeAddress { get; set; }

    public string Code { get; set; } = null!;

    public int Status { get; set; }

    public string? CodeVoucher { get; set; }

    public int? TypeVoucher { get; set; }

    public int Quantity { get; set; }

    public int TotalPrice { get; set; }

    public DateTime TimeOrder { get; set; }

    public DateTime? StartDeliveryTime { get; set; }

    public DateTime? EstimateDeliveryTime { get; set; }

    public DateTime? SuccessfulDeliveryTime { get; set; }

    public DateTime? CancellationTime { get; set; }

    public string? Note { get; set; }
}
