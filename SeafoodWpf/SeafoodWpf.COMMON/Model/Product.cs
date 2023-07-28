using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeafoodWpf.COMMON.Model;

public partial class Product
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string CategoryCode { get; set; } = null!;

    [StringLength(100)]
    public string ShopCode { get; set; } = null!;

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double? ReviewProd { get; set; }

    public int Price { get; set; }

    public int PriceSale { get; set; }

    public double? Amount { get; set; }

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
