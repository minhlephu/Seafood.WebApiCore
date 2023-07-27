using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeafoodWpf.Model;

public partial class Region
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string? NameRegion { get; set; }

    [StringLength(50)]
    public string? CodeRegion { get; set; }

    [StringLength(100)]
    public string? NameDistrict { get; set; }

    [StringLength(50)]
    public string? CodeDistrict { get; set; }

    [StringLength(100)]
    public string? NameWard { get; set; }

    [StringLength(50)]
    public string? CodeWard { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [StringLength(100)]
    public string? DeletedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(100)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }
}
