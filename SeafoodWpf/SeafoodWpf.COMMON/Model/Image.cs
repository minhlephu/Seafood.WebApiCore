using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeafoodWpf.COMMON.Model;

public partial class Image
{
    [Key]
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? ShopSeefoodId { get; set; }

    public Guid? MoreImgId { get; set; }

    [StringLength(100)]
    public string? UrlPath { get; set; }

    public string? Base64Str { get; set; }

    public bool IsImageMain { get; set; }

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
