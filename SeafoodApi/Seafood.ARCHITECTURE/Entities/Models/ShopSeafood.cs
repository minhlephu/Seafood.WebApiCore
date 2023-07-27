using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seafood.ARCHITECTURE.Entities.Models;

public partial class ShopSeafood
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string CodeRegion { get; set; } = null!;

    [StringLength(100)]
    public string CodeDistrict { get; set; } = null!;

    [StringLength(100)]
    public string CodeWard { get; set; } = null!;

    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Address { get; set; } = null!;

    public int TypeAddress { get; set; }

    [StringLength(20)]
    public string Mobile { get; set; } = null!;

    [StringLength(100)]
    public string Code { get; set; } = null!;

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
