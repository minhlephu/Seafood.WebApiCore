using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeafoodWpf.Model;

public partial class Address
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [StringLength(10)]
    public string Mobile { get; set; } = null!;

    [StringLength(50)]
    public string CodeRegion { get; set; } = null!;

    [StringLength(50)]
    public string CodeDistrict { get; set; } = null!;

    [StringLength(50)]
    public string CodeWard { get; set; } = null!;

    public int TypeAddress { get; set; }

    public int TypeAddressDetail { get; set; }

    public bool IsAddressMain { get; set; }

    [Column("Address")]
    public string Address1 { get; set; } = null!;

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
