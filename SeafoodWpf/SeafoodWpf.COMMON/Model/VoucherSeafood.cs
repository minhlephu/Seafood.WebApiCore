using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeafoodWpf.COMMON.Model;

[Index("Code", Name = "UQ__VoucherS__A25C5AA75B263AB9", IsUnique = true)]
public partial class VoucherSeafood
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(250)]
    public string Title { get; set; } = null!;

    public int TypeVoucher { get; set; }

    public int ReductionAmount { get; set; }

    [StringLength(100)]
    public string Code { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    public int? ConditionsApply { get; set; }

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
