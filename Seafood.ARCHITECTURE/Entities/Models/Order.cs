using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seafood.ARCHITECTURE.Entities.Models;

public partial class Order
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public Guid ProdProcessingId { get; set; }

    public Guid AddressId { get; set; }

    public int TypeAddress { get; set; }

    [StringLength(100)]
    public string Code { get; set; } = null!;

    public int Status { get; set; }

    [StringLength(100)]
    public string? CodeVoucher { get; set; }

    public int? TypeVoucher { get; set; }

    public int Quantity { get; set; }

    public int TotalPrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeOrder { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDeliveryTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EstimateDeliveryTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SuccessfulDeliveryTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CancellationTime { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [StringLength(100)]
    public string? DeletedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }
}
